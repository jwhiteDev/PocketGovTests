using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using NUnit.Framework;

namespace PocketGov.Tests
{
    public class ReportProblemTests : BaseTest
    {
        public ReportProblemTests(Platform platform) : base(platform)
        {

        }

        [Test]
        public void ReportAbandonedCar()
        {
            HomePage.TapFloatingActionButton();
            ReportProblemPage.TapReportAProblem();
            ReportProblemPage.SelectProblemTile();
            ReportProblemPage.TapAdditionalInformation();
            ProblemDetailsPage.TapNeedMoreInfo();
            ProblemDetailsPage.SelectPropertyType("public");
            ProblemDetailsPage.EnterVechileLocation("In an abandoned lot");
            ProblemDetailsPage.EnterLicensePlate("LATVIA");
            ProblemDetailsPage.EnterDescription("Its way too ugly");
            App.ScrollDown();
            ProblemDetailsPage.EnterEmail("jwhite@visualstudiomobilecenter.com");
            ProblemDetailsPage.EnterPhoneNumber("123-555-5432");
            ProblemDetailsPage.TapSelectLocation();

            var res = App.Query(x=>x.Marked("Location")); //This is a placeholder until next steps exist
            Assert.IsNotEmpty(res);
        }
    }
}
