using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace PocketGov.Tests
{ 
    public class ReportAdditionalDetailsPage : BasePage
    {
        protected Query needMoreInfoBtn;
        protected Query selectLocationBtn;
        protected Query selectPropertyType;
        protected Query vechileLocationField;
        protected Query licensePlateField;
        protected Query problemDescriptionField;
        protected Query emailField;
        protected Query phoneNumberField;

        public ReportAdditionalDetailsPage()
        {
            if(OnAndroid)
            {
                selectLocationBtn = x => x.Marked("Select Location of Problem");
                selectPropertyType = x => x.Class("EditText");
                vechileLocationField = x => x.Class("EntryEditText").Index(0);
                licensePlateField = x => x.Class("EntryEditText").Index(1);
                problemDescriptionField = x => x.Class("EditorEditText");
                emailField = x => x.Class("EntryEditText").Index(2);
                phoneNumberField = x => x.Class("EntryEditText").Index(3);
                needMoreInfoBtn = x => x.Marked("I Couldn't Find the Answer I Need");
            }
        }

        public void TapSelectLocation()
        {
            App.Tap(selectLocationBtn);
        }

        //This is likely the only place private/public will be used, so passing it as a param
        public void SelectPropertyType(string propType)
        {
            App.Tap(selectPropertyType);
            App.Tap(x => x.Marked(propType));
        }

        public void EnterVechileLocation(string location)
        {
            App.EnterText(vechileLocationField, location);
        }

        public void EnterLicensePlate(string plate)
        {
            App.EnterText(licensePlateField, plate);
        }

        public void EnterDescription(string description)
        {
            App.EnterText(x => x.Class("EditorEditText"), description);
        }

        public void EnterEmail(string email)
        {
            App.EnterText(emailField, email);
        }

        public void EnterPhoneNumber(string phone)
        {
            App.EnterText(phoneNumberField, phone);
        }

        public void TapNeedMoreInfo()
        {
            App.Tap(needMoreInfoBtn);
        }

    }
}
