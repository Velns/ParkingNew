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
            get { if (Places != null) return Places.Count; else return 0; }
            set 
            { 
                SetValue(PlaceCountProperty, value);
                GenearatePlaces(value);
            }
        }
        public static readonly PropertyData PlaceCountProperty = RegisterProperty(nameof(PlaceCount), typeof(int), null);


        private void GenearatePlaces(int count)
        {
            if (count > Places.Count)
            {
                for (int i = Places.Count; i < count; i++)
                {
                    Places.Add(new Place() { Number = i + 1 });
                }
            }
            else
            {
                for (int i = Places.Count; i > count; i--)
                {
                    Places.RemoveAt(i-1);
                }
            }
        }

        public Parking()
        {
            Places = new ObservableCollection<Place>();
        }
    }
}
