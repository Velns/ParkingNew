namespace ParkingProject.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using ParkingProject.Models;
    using System;
    using System.Threading.Tasks;

    public class TalonViewModel : ViewModelBase
    {
        public override string Title { get { return "View model title"; } }


        [Model]
        public Talon CurrenrTalon
        {
            get { return GetValue<Talon>(CurrenrTalonProperty); }
            private set { SetValue(CurrenrTalonProperty, value); }
        }

        public static readonly PropertyData CurrenrTalonProperty = RegisterProperty(nameof(CurrenrTalon), typeof(Talon));



        [ViewModelToModel("CurrenrTalon")]
        public string Parking
        {
            get { return GetValue<string>(ParkingProperty); }
            set { SetValue(ParkingProperty, value); }
        }
        public static readonly PropertyData ParkingProperty = RegisterProperty(nameof(Parking), typeof(string));


        [ViewModelToModel("CurrenrTalon")]
        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty(nameof(Number), typeof(string));


        [ViewModelToModel("CurrenrTalon")]
        public int Place
        {
            get { return GetValue<int>(PlaceProperty); }
            set { SetValue(PlaceProperty, value); }
        }
        public static readonly PropertyData PlaceProperty = RegisterProperty(nameof(Place), typeof(int));



        [ViewModelToModel("CurrenrTalon")]
        public string CarNumber
        {
            get { return GetValue<string>(CarNumberProperty); }
            set { SetValue(CarNumberProperty, value); }
        }
        public static readonly PropertyData CarNumberProperty = RegisterProperty(nameof(CarNumber), typeof(string));


        [ViewModelToModel("CurrenrTalon")]
        public string StartDate
        {
            get { return GetValue<string>(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }
        public static readonly PropertyData StartDateProperty = RegisterProperty(nameof(StartDate), typeof(string));


        [ViewModelToModel("CurrenrTalon")]
        public string StopDate
        {
            get { return GetValue<string>(StopDateProperty); }
            set { SetValue(StopDateProperty, value); }
        }
        public static readonly PropertyData StopDateProperty = RegisterProperty(nameof(StopDate), typeof(string));

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }
        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }


        public TalonViewModel(Talon talon = null)
        {
            CurrenrTalon = talon ?? new Talon();
        }
    }
}
