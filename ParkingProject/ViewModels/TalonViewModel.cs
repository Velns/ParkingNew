namespace Parking.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Parking.Models;
    using System;
    using System.Threading.Tasks;

    public class TalonViewModel : ViewModelBase
    {
        public override string Title { get { return "View model title"; } }

        [Model]
        public Talon TalonObject
        {
            get { return GetValue<Talon>(TalonObjectProperty); }
            private set { SetValue(TalonObjectProperty, value); }
        }
        public static readonly PropertyData TalonObjectProperty = RegisterProperty(nameof(TalonObject), typeof(Talon));


        [ViewModelToModel("TalonObject", "Parking")]
        public string TalonParking
        {
            get { return GetValue<string>(TalonParkingProperty); }
            set { SetValue(TalonParkingProperty, value); }
        }
        public static readonly PropertyData TalonParkingProperty = RegisterProperty(nameof(TalonParking), typeof(string));

        [ViewModelToModel("TalonObject", "Number")]
        public string TalonNumber   
        {
            get { return GetValue<string >(nameProperty); }
            set { SetValue(nameProperty, value); }
        }
        public static readonly PropertyData nameProperty = RegisterProperty(nameof(TalonNumber), typeof(string ));


        [ViewModelToModel("TalonObject", "CarNumber")]
        public string TalonCarNumber
        {
            get { return GetValue<string>(TalonCarNumberProperty); }
            set { SetValue(TalonCarNumberProperty, value); }
        }
        public static readonly PropertyData TalonCarNumberProperty = RegisterProperty(nameof(TalonCarNumber), typeof(string));

        [ViewModelToModel("TalonObject", "Place")]
        public int TalonPlaceNumber
        {
            get { return GetValue<int>(PlaceNumberProperty); }
            set { SetValue(PlaceNumberProperty, value); }
        }
        public static readonly PropertyData PlaceNumberProperty = RegisterProperty(nameof(TalonPlaceNumber), typeof(int));

        [ViewModelToModel("TalonObject", "StartDate")]
        public string TalonStartDate
        {
            get { return GetValue<string>(TalonStartDateProperty); }
            set { SetValue(TalonStartDateProperty, value); }        }
        public static readonly PropertyData TalonStartDateProperty = RegisterProperty(nameof(TalonStartDate), typeof(string), null);

        [ViewModelToModel("TalonObject", "StopDate")]
        public string TalonStopDate
        {
            get { return GetValue<string>(TalonStopDateProperty); }
            set { SetValue(TalonStopDateProperty, value); }
        }
        public static readonly PropertyData TalonStopDateProperty = RegisterProperty(nameof(TalonStopDate), typeof(string));

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
            TalonObject = talon ?? new Talon();
        }
    }
}
