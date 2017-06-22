using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PocketGov.Tests
{
    public class HomePage : BasePage
    {
        protected Query titleBar;
        protected Query fab;
        readonly Query flyoutMenuButton;
        readonly Query loginButton;
        readonly Query logoutButton;

        public HomePage()
        {
            if(OnAndroid)
            {
                titleBar = x => x.Marked("Pocketgov Denver");
                fab = x => x.Class("FormsImageView");
                flyoutMenuButton = x => x.Marked("OK");
                loginButton = x => x.Marked("Login");
                logoutButton = x => x.Marked("Logout");
            }
        }

        public void WaitToLoad()
        {
            Wait(titleBar);
            App.Screenshot("Loaded Main Page");
        }

        public void TapFloatingActionButton()
        {
            App.Tap(fab);
        }

        //Flyout Menu Navigation
        public void OpenFlyoutMenu()
        {
            App.Tap(flyoutMenuButton);
            App.Screenshot("Open Sidebar");
        }

        public void TapLoginButton()
        {
            App.Tap(loginButton);
            App.Screenshot("Select Login Option");
        }

        public void TapLogoutButton()
        {
            App.Tap(logoutButton);
        }
    }
}
