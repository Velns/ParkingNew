using Catel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    public class Parking: ValidatableModelBase
    {
        public int ID { set; get; }

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


        public ObservableCollection<Place> Places
        {
            get { return GetValue<ObservableCollection<Place>>(PlacesProperty); }
            set { SetValue(PlacesProperty, value); }
        }
        public static readonly PropertyData PlacesProperty = RegisterProperty(nameof(Places), typeof(ObservableCollection<Place>), null);



        public int PlaceCount
        {
            get { return GetValue<int>(PlaceCountProperty); }
            set { SetValue(PlaceCountProperty, value); }
        }
        public static readonly PropertyData PlaceCountProperty = RegisterProperty(nameof(PlaceCount), typeof(int), null);


        

        public Parking()
        {
            Places = new ObservableCollection<Place>();
        }
    }
}
