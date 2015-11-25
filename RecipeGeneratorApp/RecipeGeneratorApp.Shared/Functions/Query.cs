using RecipeGeneratorApp.model_class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace RecipeGeneratorApp.Functions
{
    public class Query: ViewModelBase
    {
        private ObservableCollection<Variables> likes;

        public ObservableCollection<Variables> Likes
        {
            get { return likes; }
            set { likes = value; RaisePropertyChanged("Likes"); }
        }

        private RecipeGeneratorApp.App app = (Application.Current as App);

        public ObservableCollection<Variables> getRows(string name)
        {
            likes = new ObservableCollection<Variables>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<Likes>("select * from Likes where recipeName = '"+name+"'");
                foreach (var _results in query)
                {
                    var res = new Variables()
                    {
                        Id = _results.likesId,
                        Member = _results.memName,
                        RecipeName = _results.recipeName
                    };
                    likes.Add(res);
                }
            }
            return likes;
        }
    }
}
