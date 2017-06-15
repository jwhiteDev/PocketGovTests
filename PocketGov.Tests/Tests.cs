using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace PocketGov.Tests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        protected IApp app;
        protected Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = AppInitializer.StartApp(platform);
        }

        [Ignore]
        [Test]
        public void ReplTest()
        {
            app.Screenshot("First screen.");
            app.Repl();
        }

        [Test]
        public void LoginTest()
        {
            Wait(c => c.Marked("Pocketgov Denver"));
            app.Screenshot("Initial Homescreen");
            app.Tap(x => x.Marked("OK"));
            app.Screenshot("Open Sidebar");
            app.Tap(x => x.Marked("Login"));
            app.Screenshot("Select Login Option");
            app.EnterText(x => x.Class("EntryEditText").Index(0), "yasu.hotta@gmail.com");
            app.EnterText(x => x.Class("EntryEditText").Index(1), "Passw0rd!");
            app.DismissKeyboard();
            app.Screenshot("Enter Login Details");
            app.Tap("Login To Pocketgov");
            Wait(c => c.Marked("Pocketgov Denver"));
            app.Screenshot("Then I should be logged in");
            app.Tap("OK");
            app.Screenshot("Verify if Login was recognized");

            var res = app.Query("Profile");
            Assert.IsNotEmpty(res);
        }

        [Test]
        public void LogoutTest()
        {
            Wait(c => c.Marked("Pocketgov Denver"));
            app.Screenshot("On the Homescreen");
            app.Tap(x => x.Marked("OK"));
            app.Screenshot("Open Sidebar to Logout");
            app.Tap("Logout");
            app.Tap("OK");
            app.Screenshot("Verify Success");

           var res = app.Query("Login");
           Assert.IsNotEmpty(res);
        }

        private void Wait(Func<AppQuery, AppQuery> lambda)
        {
            app.WaitForElement(lambda, $"Unable to load {lambda.ToString()}", new TimeSpan(0, 0, 0, 15, 0));
        }
    }
}

