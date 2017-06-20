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

        public HomePage()
        {
            if(OnAndroid)
            {
                titleBar = x => x.Marked("Pocketgov Denver");
            }
        }

        public void WaitToLoad()
        {
            Wait(titleBar);
            App.Screenshot("Loaded Main Page");
        }
    }
}
