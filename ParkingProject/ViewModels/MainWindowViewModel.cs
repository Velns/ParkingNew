namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;
    using Catel;
    using System.Data.Entity.Migrations;
    using System.Data.Entity;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;

        private readonly IViewModel carsViewModel;
        private readonly IViewModel feedBackViewModel;
        private readonly IViewModel signInViewModel;
        private readonly IViewModel talonsViewModel;
        private readonly IViewModel usersViewModel;
        private readonly IViewModel parkingsViewModel;

        CarContext dbCar = new CarContext();
        FeedbackContext dbFeedback = new FeedbackContext();
        ParkingContext dbParking = new ParkingContext();
        PlaceContext dbPlace = new PlaceContext();
        TalonContext dbTalon = new TalonContext();
        UserContext dbUser = new UserContext();

        private User _currUser = new User();
        private bool isLogined = false;

        public override string Title { get { return "Parking"; } }

        public IViewModel CurrentViewModel
        {
            get { return GetValue<IViewModel>(CurrentViewModelProperty); }
            set { SetValue(CurrentViewModelProperty, value); }
        }
        public static readonly PropertyData CurrentViewModelProperty = RegisterProperty(nameof(CurrentViewModel), typeof(IViewModel), null);

        public double OpacityView
        {
            get { return GetValue<double>(OpacityViewProperty); }
            set { SetValue(OpacityViewProperty, value); }
        }
        public static readonly PropertyData OpacityViewProperty = RegisterProperty(nameof(OpacityView), typeof(double), null);

        public Command ShowUsersView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(usersViewModel);
                });
            }
        }
        public Command ShowCarsView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(carsViewModel);
                });
            }
        }
        public Command ShowTalonsView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(talonsViewModel);
                });
            }
        }
        public Command ShowFeedBackView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(feedBackViewModel);
                });
            }
        }
        public Command ShowParkingsView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(parkingsViewModel);
                });
            }
        }

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            carsViewModel = new CarsViewModel(_uiVisualizerService,dbCar);
            feedBackViewModel = new FeedBackViewModel(dbFeedback);
            signInViewModel = new SignInViewModel(_currUser, isLogined, dbUser);
            talonsViewModel = new TalonsViewModel(_uiVisualizerService, dbTalon);
            usersViewModel = new UsersViewModel(dbUser);
            parkingsViewModel = new ParkingsViewModel(_uiVisualizerService, dbParking, dbPlace);
            dbUser.Users.Add(new User());
            dbUser.SaveChanges();
            isLogined = true;//            SlowChangeView(signInViewModel);
        }
        private async void SlowChangeView(IViewModel newViewModel)
        {
            if (isLogined || newViewModel == signInViewModel)
            {
                await Task.Factory.StartNew(() =>
                {
                    for (double i = 1; OpacityView > 0; i -= 0.2)
                    {
                        OpacityView = i;
                        ThreadHelper.Sleep(25);
                    }
                    CurrentViewModel = newViewModel;
                    for (double i = 0; OpacityView <= 1.1; i += 0.2)
                    {
                        OpacityView = i;
                        ThreadHelper.Sleep(25);
                    }
                });
            }
        }

        protected override Task CloseAsync()
        {
            dbCar.Dispose();
            dbFeedback.Dispose();
            dbParking.Dispose();
            dbPlace.Dispose();
            dbTalon.Dispose();
            dbUser.Dispose();
            return base.CloseAsync();
        }
        protected override Task InitializeAsync()
        {
            return base.InitializeAsync();
        }
    }
    public class ProjectInitializer : MigrateDatabaseToLatestVersion<CarContext, Configuration>
    {
    }
    public sealed class Configuration : DbMigrationsConfiguration<CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarContext context)
        {

        }
    }
}
