using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PocketGov.Tests
{
    public class LoginPage : BasePage
    {
        readonly Query usernameField;
        readonly Query passwordField;
        readonly Query loginButton;

        public LoginPage()
        {
            if(OnAndroid)
            {
                usernameField = x => x.Class("EntryEditText").Index(0);
                passwordField = x => x.Class("EntryEditText").Index(1);
                loginButton = x => x.Marked("Login To Pocketgov");
            }
        }

        public void EnterUsername(string username)
        {
            App.EnterText(usernameField, username);
            App.DismissKeyboard();
            App.Screenshot("Now I enter username");
        }

        public void EnterPassword(string password)
        {
            App.EnterText(passwordField, password);
            App.DismissKeyboard();
            App.Screenshot("Now I enter password");
        }

        public void TapLoginButton()
        {
            App.Tap(loginButton);
        }
    }
}
