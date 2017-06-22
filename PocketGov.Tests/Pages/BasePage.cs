using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PocketGov.Tests
{
    public class BasePage
    {
        protected IApp App => AppInitializer.App;
        protected bool OnAndroid { get; set; }
        protected bool OniOS { get; set; }


        public BasePage()
        {
            OnAndroid = App.GetType() == typeof(AndroidApp);
            OniOS = App.GetType() == typeof(iOSApp);
        }

        /// <summary>
        /// Verify item is on page, wait for it to load
        /// </summary>
        protected void Wait(Func<AppQuery, AppQuery> trait)
        {
            Assert.DoesNotThrow(() => App.WaitForElement(trait, $"Unable to load {trait.ToString()}", new TimeSpan(0, 0, 0, 15, 0)));
        }

        
    }
}
