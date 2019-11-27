namespace Parking.ViewModels
{
    using Catel.MVVM;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Parking.Models;
    using Catel.Data;
    using Catel.Services;

    public class TalonsViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        public TalonsViewModel(/* dependency injection here */IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;
            TalonsCollection = new ObservableCollection<Talon>();
            TalonsCollection.Add(new Talon() { Parking="1", Number="1", Place=1, StartDate="1", StopDate="1"});
        }

        public override string Title { get { return "View model title"; } }

        public ObservableCollection<Talon> TalonsCollection
        {
            get { return GetValue<ObservableCollection<Talon>>(TalonsColectionProperty); }
            set { SetValue(TalonsColectionProperty, value); }
        }
        public static readonly PropertyData TalonsColectionProperty = RegisterProperty(nameof(TalonsCollection), typeof(ObservableCollection<Talon>), null);

        public Talon SelectedTalon
        {
            get { return GetValue<Talon>(SelectedTalonProperty); }
            set { SetValue(SelectedTalonProperty, value); }
        }
        public static readonly PropertyData SelectedTalonProperty = RegisterProperty(nameof(SelectedTalon), typeof(Talon), null);

        private Command _addTalon;
        public Command AddTalon
        {
            get
            {
                return _addTalon ?? (_addTalon = new Command(() =>
                {
                    var viewModel = new TalonViewModel();

                    _uiVisualizerService.ShowDialogAsync(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            TalonsCollection.Add(viewModel.TalonObject);
                        }
                    });
                }));
            }
        }

        private Command _editTalon;
        public Command EditTalon
        {
            get
            {
                return _editTalon ?? (_editTalon = new Command(() =>
                {
                    var viewModel = new TalonViewModel(SelectedTalon);
                    _uiVisualizerService.ShowDialogAsync(viewModel);
                },
                () => SelectedTalon != null));
            }
        }

        private Command _removeTalon;
        public Command RemoveTalon
        {
            get
            {
                return _removeTalon ?? (_removeTalon = new Command(async () =>
                {
                    TalonsCollection.Remove(SelectedTalon);
                },
                () => SelectedTalon != null));
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
