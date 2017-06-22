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
    public class BaseTest
    {
        protected IApp App => AppInitializer.App;
        protected Platform platform;

        protected LoginPage LoginPage;
        protected HomePage HomePage;
        protected ReportProblemPage ReportProblemPage;
        protected ReportAdditionalDetailsPage ProblemDetailsPage;

        public BaseTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            AppInitializer.StartApp(platform);
            LoginPage = new LoginPage();
            HomePage = new HomePage();
            ReportProblemPage = new ReportProblemPage();
            ProblemDetailsPage = new ReportAdditionalDetailsPage();
        }

    }
}

