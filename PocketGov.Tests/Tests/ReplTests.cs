using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace PocketGov.Tests
{
    public class ReplTests : BaseTest
    {
        public ReplTests(Platform platform) : base(platform)
        {
        }

        [Ignore] //Ignore test for now in main test runs, only us when needed
        [Test]
        public void ReplTest()
        {
            App.Repl();
        }
    }
}
