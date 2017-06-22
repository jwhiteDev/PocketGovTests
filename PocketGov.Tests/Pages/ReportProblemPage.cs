using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PocketGov.Tests
{
    public class ReportProblemPage : BasePage
    {
        protected Query reportProblemBtn;
        protected Query abandonedVechicleTile;
        protected Query additionalInfoBtn;

        public ReportProblemPage()
        {
            if(OnAndroid)
            {
                reportProblemBtn = x => x.Marked("Report a Problem");
                abandonedVechicleTile = x => x.Marked("Abandoned Vehicle");
                additionalInfoBtn = x => x.Marked("Enter Additional Information");
            }
        }

        public void TapReportAProblem()
        {
            App.Tap(reportProblemBtn);
        }

        public void SelectProblemTile()
        {
            //Either create a section/option menu the test can pass in 
            //to have one method for all options or a method per issue
            App.Tap(abandonedVechicleTile);
        }

        public void TapAdditionalInformation()
        {
            App.Tap(additionalInfoBtn);
        }

    }
}
