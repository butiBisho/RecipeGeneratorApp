using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

namespace RecipeGeneratorApp.Functions
{
    public class Message
    {
        public async void msgBox(string msg)
        {
            var msgDisplay = new MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
    }
}
