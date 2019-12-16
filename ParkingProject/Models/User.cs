using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace ParkingProject.Models
{
    public class User : ValidatableModelBase
    {
        public int ID { set; get; }

        public string Login
        {
            get { return GetValue<string>(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly PropertyData LoginProperty = RegisterProperty(nameof(Login), typeof(string), null);
        
        public string Pass
        {
            get { return GetValue<string>(PassProperty); }
            set { SetValue(PassProperty, value); }
        }
        public static readonly PropertyData PassProperty = RegisterProperty(nameof(Pass), typeof(string), null);

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);
        
        public string PhoneNum
        {
            get { return GetValue<string>(PhoneNumProperty); }
            set { SetValue(PhoneNumProperty, value); }
        }
        public static readonly PropertyData PhoneNumProperty = RegisterProperty(nameof(PhoneNum), typeof(string), null);

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Login != "Login")
            {
                validationResults.Add(FieldValidationResult.CreateError(LoginProperty, "Wrong Login"));
            }

            if (Pass != "Pass") 
            {
                validationResults.Add(FieldValidationResult.CreateError(PassProperty, "Wrong Password"));
            }
        }

    }
}
