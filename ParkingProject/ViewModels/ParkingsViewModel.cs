namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;

    public class ParkingsViewModel : ViewModelBase
    {
        private IUIVisualizerService _uiVisualizerService;

        public ParkingsViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;
            ParkingsCollection = new ObservableCollection<Parking>()
            {
                new Parking() {Name="1", Address="1", Places = new ObservableCollection<Place>{new Place(), new Place() } },
                new Parking() {Name="2", Address="2", Places = new ObservableCollection<Place>{new Place() } }
            } ; 
        }


        public ObservableCollection<Parking> ParkingsCollection
        {
            get { return GetValue<ObservableCollection<Parking>>(ParkingsCollectionProperty); }
            set { SetValue(ParkingsCollectionProperty, value); }
        }
        public static readonly PropertyData ParkingsCollectionProperty = RegisterProperty(nameof(ParkingsCollection), typeof(ObservableCollection<Parking>), null);
        

        public Parking SelectedParking
        {
            get { return GetValue<Parking>(SelectedParkingProperty); }
            set { SetValue(SelectedParkingProperty, value); }
        }
        public static readonly PropertyData SelectedParkingProperty = RegisterProperty(nameof(SelectedParking), typeof(Parking), null);
        

        private Command _addParking;
        public Command AddParking
        {
            get
            {
                return _addParking ?? (_addParking = new Command(() =>
                {
                    var viewModel = new ParkingViewModel();

                    _uiVisualizerService.ShowDialogAsync(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            ParkingsCollection.Add(viewModel.CurrentParking);
                        }
                    });
                }));
            }
        }
        

        private Command _editParking;
        public Command EditParking
        {
            get
            {
                return _editParking ?? (_editParking = new Command(() =>
                {
                    var viewModel = new ParkingViewModel(SelectedParking);
                    _uiVisualizerService.ShowDialogAsync(viewModel);
                },
                () => SelectedParking != null));
            }
        }
        

        private Command _removeParking;
        public Command RemoveParking
        {
            get
            {
                return _removeParking ?? (_removeParking = new Command(async () =>
                {
                    ParkingsCollection.Remove(SelectedParking);
                },
                () => SelectedParking != null));
            }
        }


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
    }
}
