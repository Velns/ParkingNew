namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;
    using System.Data.Entity;

    public class CarsViewModel : ViewModelBase
    {
        CarContext db = new CarContext();
        private IUIVisualizerService _uiVisualizerService;
        public CarsViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;
            CarsCollection = new ObservableCollection<Car>();
            db.Cars.Load();
            LoadCollection();

            //CarsCollection = new ObservableCollection<Car>
            //{
            //    new Car() { Number = "1", Model = "1", Color="1" },
            //    new Car() { Number = "2", Model = "2", Color="2" }
            //};
        }


        public ObservableCollection<Car> CarsCollection
        {
            get { return GetValue<ObservableCollection<Car>>(CarsCollectionProperty); }
            set 
            { 
                SetValue(CarsCollectionProperty, value); 
                
            }
        }
        public static readonly PropertyData CarsCollectionProperty = RegisterProperty(nameof(CarsCollection), typeof(ObservableCollection<Car>), null);


        public Car SelectedCar
        {
            get { return GetValue<Car>(SelectedCarProperty); }
            set { SetValue(SelectedCarProperty, value); }
        }
        public static readonly PropertyData SelectedCarProperty = RegisterProperty(nameof(SelectedCar), typeof(Car), null);


        private Command _addCar;
        public Command AddCar
        {
            get
            {
                return _addCar ?? (_addCar = new Command(() =>
                {
                    var viewModel = new CarViewModel();

                    _uiVisualizerService.ShowDialogAsync(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            CarsCollection.Add(viewModel.CurrentCar);
                            db.Cars.Add(viewModel.CurrentCar);
                            db.SaveChanges();
                        }
                    });
                }));
            }
        }


        private Command _editCar;
        public Command EditCar
        {
            get
            {
                return _editCar ?? (_editCar = new Command(() =>
                {
                    var viewModel = new CarViewModel(SelectedCar); Task a =
                     _uiVisualizerService.ShowDialogAsync(viewModel);
                    
                },
                () => SelectedCar != null));
            }
        }


        private Command _removeCar;
        public Command RemoveCar
        {
            get
            {
                return _removeCar ?? (_removeCar = new Command(async () =>
                {
                    db.Cars.Remove(SelectedCar);
                    CarsCollection.Remove(SelectedCar);
                    db.SaveChanges();
                },
                () => SelectedCar != null));
            }
            
        }

        private Command _saveCar;
        public Command SaveCar
        {
            get
            {
                return _saveCar ?? (_saveCar = new Command(async () =>
                {
                    db.SaveChanges();
                }));
            }
        }


        private void LoadCollection()
        {
            foreach (var c in db.Cars)
            {
                CarsCollection.Add(c);
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
            db.Dispose();
        }
    }
}
