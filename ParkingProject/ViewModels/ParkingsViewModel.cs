namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;
    using System.Data.Entity;
    using System.Windows;

    public class ParkingsViewModel : ViewModelBase
    {
        private IUIVisualizerService _uiVisualizerService;
        private ParkingContext db;
        //private PlaceContext dbPlace;
        public ParkingsViewModel(IUIVisualizerService uiVisualizerService, ParkingContext dbParking/*, PlaceContext dbPlace*/)
        {
            _uiVisualizerService = uiVisualizerService;
            db = dbParking;
            //this.dbPlace = dbPlace;
            ParkingsCollection = new ObservableCollection<Parking>();
            db.Parkings.Load();
            db.Places.Load();
            LoadCollection();
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
                    var viewModel = new ParkingViewModel(db/*, dbPlace*/);

                    _uiVisualizerService.ShowDialogAsync(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            ParkingsCollection.Add(viewModel.CurrentParking);
                            db.Parkings.Add(viewModel.CurrentParking);
                            db.SaveChangesAsync();
                            //dbPlace.SaveChanges();
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
                    var viewModel = new ParkingViewModel(db/*, dbPlace*/, SelectedParking);
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
                    db.Places.RemoveRange(SelectedParking.Places);
                    
                    db.Parkings.Remove(SelectedParking);
                    ParkingsCollection.Remove(SelectedParking);                    
                    db.SaveChanges();
                },
                () => SelectedParking != null));
            }
        }

        private Command _saveParkings;
        public Command SaveParkings
        {
            get
            {
                return _saveParkings ?? (_saveParkings = new Command(async () =>
                {
                    await db.SaveChangesAsync();
                    //dbPlace.SaveChanges();
                }));
            }
        }
        private void LoadCollection()
        {
            foreach (var p in db.Parkings)
            {
                ParkingsCollection.Add(p);
            //    foreach (var place in dbPlace.Places)
            //    {
            //        MessageBox.Show(place.ID.ToString() + ' ' + place.IDParking);
            //        if (place.IDParking == p.ID) p.Places.Add(place);
            //    }
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
