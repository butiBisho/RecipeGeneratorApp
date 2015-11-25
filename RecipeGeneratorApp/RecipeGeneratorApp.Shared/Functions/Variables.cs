using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeGeneratorApp.Functions
{
    public class Variables: ViewModelBase
    {
        #region Properties

        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string recipeName = "";
        public string RecipeName
        {
            get
            { return recipeName; }

            set
            {
                if (recipeName == value)
                { return; }

                recipeName = value;
                RaisePropertyChanged("recipeName");
            }
        }

        private string member = "";
        public string Member
        {
            get
            { return member; }

            set
            {
                if (member == value)
                { return; }

                member = value;
                RaisePropertyChanged("memName");
            }
        }
        #endregion "Properties"


    }
}
