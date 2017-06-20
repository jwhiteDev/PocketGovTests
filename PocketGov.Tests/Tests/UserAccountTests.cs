using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;

namespace PocketGov.Tests
{
    public class UserAccountTests : BaseTest
    {
        public UserAccountTests(Platform platform) 
            : base(platform)
        {
        }

        [Test]
        public void LoginTest()
        {
            HomePage.WaitToLoad();
            HomePage.OpenFlyoutMenu();
            HomePage.TapLoginButton();
            LoginPage.EnterUsername("yasu.hotta@gmail.com");
            LoginPage.EnterPassword("Passw0rd!");
            LoginPage.TapLoginButton();
            HomePage.WaitToLoad();
            App.Screenshot("Then I should be logged in");
            HomePage.OpenFlyoutMenu();
            App.Screenshot("Verify if Login was recognized");

            var res = App.Query("Profile");
            Assert.IsNotEmpty(res);
        }

        [Test]
        public void LogoutTest()
        {
            HomePage.WaitToLoad();
            HomePage.OpenFlyoutMenu();
            App.Screenshot("Open Sidebar to Logout");
            HomePage.TapLogoutButton();
            HomePage.OpenFlyoutMenu();
            App.Screenshot("Verify Success");

            var res = App.Query("Login");
            Assert.IsNotEmpty(res);
        }

    }
}
