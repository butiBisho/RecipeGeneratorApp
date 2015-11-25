using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeGeneratorApp.Functions
{
    public class Validate
    {
        public int MemberExistance(string email)
        {
            int a = 0;//false
            Insert newMember = new Insert();
            var data = newMember.memberExistance(email);
            if (data != null)
            {
                a = 1;//true
            }
            return a;
        }

        public int loginError(string _email, string _password)
        {
            int a = 0;
            Insert newMember = new Insert();
            var data = newMember.LogIn(_email, _password);
            if (data != null)
            {
                a = 1;//meaning user exists
            }
            return a;
        }
    }
}
