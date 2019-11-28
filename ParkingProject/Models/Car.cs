using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Car : ValidatableModelBase
    {

        public string Model
        {
            get { return GetValue<string>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly PropertyData ModelProperty = RegisterProperty("Model", typeof(string), string.Empty);

        public string Color
        {
            get { return GetValue<string>(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly PropertyData ColorProperty = RegisterProperty("Color", typeof(string), string.Empty);

        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly PropertyData NumberProperty = RegisterProperty("Number", typeof(string), string.Empty);
    }
}
