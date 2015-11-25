using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RecipeGeneratorApp.Functions
{
    public class Controls
    {
        //check if controls contains only string characters
        public int validateString(string line)
        {
            int a = 0;
            for (int y = 0; y < line.Length; y++)
            {
                if (char.IsNumber(line[y]) == true)
                    a = 1;
            }
            return a;
        }

        public int validateEmail(string line)
        {
            int a = 0;
            if (!Regex.IsMatch(line, @"^[a-zA-Z][\w\.-]*[a-zAZ0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                //display error message
                a = 1;
            }
            return a;
        }

        public int comparePasswords(string password, string confirm)
        {
            int a = 0;
            if (password == confirm)
            {
                a = 1;
            }
            return a;
        }
    }
}
