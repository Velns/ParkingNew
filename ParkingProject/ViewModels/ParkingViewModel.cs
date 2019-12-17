namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;

    public class ParkingViewModel : ViewModelBase
    {
        private ParkingContext db;
        //private PlaceContext dbPlace;
        [Model]
        public Parking CurrentParking
        {
            get { return GetValue<Parking>(CurrentParkingProperty); }
            private set { SetValue(CurrentParkingProperty, value); }
        }
        public static readonly PropertyData CurrentParkingProperty = RegisterProperty(nameof(CurrentParking), typeof(Parking));


        [ViewModelToModel("CurrentParking")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));

        [ViewModelToModel("CurrentParking")]
        public string Address
        {
            get { return GetValue<string>(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }
        public static readonly PropertyData AddressProperty = RegisterProperty(nameof(Address), typeof(string));


        [ViewModelToModel("CurrentParking")]
        public ObservableCollection<Place> Places
        {
            get { return GetValue<ObservableCollection<Place>>(PlacesProperty); }
            set { SetValue(PlacesProperty, value); }
        }

        public static readonly PropertyData PlacesProperty = RegisterProperty(nameof(Places), typeof(ObservableCollection<Place>));
        [ViewModelToModel("CurrentParking")]
        public int PlaceCount
        {
            get
            {
                if (Places != null)
                {
                    GetValue<int>(PlaceCountProperty);
                    return Places.Count;
                }
                else return 0;
            }
            set
            {
                SetValue(PlaceCountProperty, value);
                GenearatePlaces(value);
            }

        }
        public static readonly PropertyData PlaceCountProperty = RegisterProperty(nameof(PlaceCount), typeof(int));

        public Place SelectedPlace
        {
            get { return GetValue<Place>(SelectedPlaceProperty); }
            set { SetValue(SelectedPlaceProperty, value); }
        }
        public static readonly PropertyData SelectedPlaceProperty = RegisterProperty(nameof(SelectedPlace), typeof(Place), null);

        public override string Title { get { return "View model title"; } }

        public Command ChangePlaceStatus
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedPlace != null)  SelectedPlace.IsEmpty = !SelectedPlace.IsEmpty;
                });
            }
        }
        private void GenearatePlaces(int count)
        {
            if (count > Places.Count)
            {
                for (int i = Places.Count; i < count; i++)
                {
                    Place a = new Place() { Number = i + 1, Parking = CurrentParking };
                    db.Places.Add(a);
                   // Places.Add(a);
                    
                }
            }
            else
            {
                for (int i = Places.Count; i > count; i--)
                {
                    db.Places.Remove(Places[i - 1]);
                }
            }
            db.SaveChangesAsync();
        }
        public ParkingViewModel(ParkingContext dbParking, /*PlaceContext dbPlace,*/ Parking parking = null)
        {
            CurrentParking = parking ?? new Parking();
            db = dbParking;
            //this.dbPlace = dbPlace;
        }
    }
}
