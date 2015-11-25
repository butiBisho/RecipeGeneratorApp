using RecipeGeneratorApp.model_class;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using System.Linq;

namespace RecipeGeneratorApp.Functions
{
    public class Insert
    {
        private RecipeGeneratorApp.App app = (Application.Current as App);

        public void memberDetails(string _name, string _surname, string _email, string _password)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new Member()
                {
                    memId = 0,
                    name = _name,
                    surname = _surname,
                    email = _email,
                    password = _password
                });
            }
        }

        public Member memberExistance(string email)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<Member>("select * from Member where email = '" + email + "'").FirstOrDefault();
                return query;
            }
        }

        public Member LogIn(string email, string password)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<Member>("select * from Member where email = '" + email + "' and password = '" + password + "'").FirstOrDefault();
                return query;
            }
        }

        public Likes countRecipeLikes(string recipeName)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<Likes>("select Count(*) from Likes where recipeName = '"+recipeName+"'").FirstOrDefault();
                return query;
            }
        }

        public void InsertUserLikes(string recipeName, string memberName)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new Likes()
                {
                    likesId = 0,
                    memName = memberName,
                    recipeName = recipeName
                });
            }
        }


    }
}
