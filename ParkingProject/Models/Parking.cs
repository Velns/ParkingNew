using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parking.Models
{
    class Parking: ValidatableModelBase
    {

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        public string Address
        {
            get { return GetValue<string>(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public static readonly PropertyData AddressProperty = RegisterProperty(nameof(Address), typeof(string), null);

        //public List<Place> Places
        //{
        //    get { return GetValue<List<Place>>(PlacesProperty); }
        //    set { SetValue(PlacesProperty, value); }
        //}

        //public static readonly PropertyData PlacesProperty = RegisterProperty(nameof(Places), typeof(List<Place>), null);
    }
}
