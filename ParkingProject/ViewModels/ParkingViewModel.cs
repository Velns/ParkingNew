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
        public int PlaceCount
        {
            get { return GetValue<int>(PlaceCountProperty); }
            set 
            { 
                SetValue(PlaceCountProperty, value);
                
                
            }
        }

        public static readonly PropertyData PlaceCountProperty = RegisterProperty(nameof(PlaceCount), typeof(int));
        public override string Title { get { return "View model title"; } }


        public ParkingViewModel(Parking parking = null)
        {
            CurrentParking = parking ?? new Parking();
        }
    }
}
