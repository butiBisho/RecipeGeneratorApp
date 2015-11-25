using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RecipeGeneratorApp.model_class
{
    [Table("Likes")]
    public class Likes
    {
        [PrimaryKey, AutoIncrement]
        public int likesId { get; set; }
        public string recipeName { get; set; }
        public string memName { get; set; }
    }
}
