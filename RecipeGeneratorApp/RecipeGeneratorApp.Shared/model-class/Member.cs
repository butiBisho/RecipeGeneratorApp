using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeGeneratorApp.model_class
{
    [Table("Member")]
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int memId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
