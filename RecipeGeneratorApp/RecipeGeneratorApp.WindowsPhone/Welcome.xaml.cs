using RecipeGeneratorApp.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace RecipeGeneratorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Welcome : Page
    {
        Message msg = new Message();
        Controls monitor = new Controls();
        Insert newMember = new Insert();
        Validate validate = new Validate();
        public Welcome()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void checkFields()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            pwbxPassword.Password = "";
            pwbxConfirm.Password = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int email = monitor.validateEmail(txtLoginEmail.Text.Trim());

            if (txtLoginEmail.Text.Length == 0 && pwbxLoginPassword.Password.Length == 0)
            {
                msg.msgBox("Textbox fields cannot be left empty");
            }
            else if (txtLoginEmail.Text.Length == 0)
            {
                msg.msgBox("Email field cannot be left empty");
            }
            else if (pwbxLoginPassword.Password.Length == 0)
            {
                msg.msgBox("Password field cannot be left empty");
            }
            else
            {
                if (email == 1)
                {
                    msg.msgBox("Enter a valid email");
                }
                else
                {
                    //redirect to another page
                    int wrong = validate.loginError(txtLoginEmail.Text.Trim(), pwbxLoginPassword.Password.Trim());
                    if (wrong == 1)
                    {
                        msg.msgBox("Successful login");
                        this.Frame.Navigate(typeof(HubPage), txtLoginEmail.Text);
                    }
                    else
                    {
                        msg.msgBox("Sorry! The details entered don't exist");
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            int name = monitor.validateString(txtName.Text.Trim());
            int surname = monitor.validateString(txtSurname.Text.Trim());
            int email = monitor.validateEmail(txtEmail.Text.Trim());
            int comparePasswords = monitor.comparePasswords(pwbxPassword.Password, pwbxConfirm.Password);

            try
            {
                if (txtName.Text.Length == 0 && txtSurname.Text.Length == 0 && txtEmail.Text.Length == 0 && pwbxPassword.Password.Length == 0 && pwbxConfirm.Password.Length == 0)
                {
                    msg.msgBox("Textbox fields cannot be left empty");
                }
                else if (txtName.Text.Length == 0)
                {
                    msg.msgBox("Name field cannot be left empty");
                }
                else if (txtSurname.Text.Length == 0)
                {
                    msg.msgBox("Surname field cannot be left empty");
                }
                else if (txtEmail.Text.Length == 0)
                {
                    msg.msgBox("Email field cannot be left empty");
                }
                else if (pwbxPassword.Password.Length == 0)
                {
                    msg.msgBox("Password field cannot be left empty");
                }
                else if (pwbxConfirm.Password.Length == 0)
                {
                    msg.msgBox("Confirm Password field cannot be left empty");
                }
                else
                {
                    if (name == 1 || surname == 1)
                    {
                        msg.msgBox("Enter string characters");
                    }
                    else if (email == 1)
                    {
                        msg.msgBox("Enter a valid email");
                        txtEmail.Text = "";
                    }
                    else if (comparePasswords == 0)
                    {
                        msg.msgBox("Both passwords must be correct");
                        pwbxPassword.Password = "";
                        pwbxConfirm.Password = "";
                    }
                    else
                    {
                        //insert into database
                        int checkMember = validate.MemberExistance(txtEmail.Text.Trim());
                        if (checkMember == 1)
                        {
                            msg.msgBox("User already Exists");
                        }
                        else
                        {
                            newMember.memberDetails(txtName.Text.Trim(), txtSurname.Text.Trim(), txtEmail.Text.Trim(), pwbxPassword.Password.Trim());
                            msg.msgBox("Successfully registered. You may login");
                            checkFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg.msgBox(ex.Message);
            }
        }




    }
}
