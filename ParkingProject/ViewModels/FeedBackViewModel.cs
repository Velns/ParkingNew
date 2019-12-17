namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using ParkingProject.Models;
    using System.Threading.Tasks;

    public class FeedBackViewModel : ViewModelBase
    {
        private FeedbackContext db;
        public FeedBackViewModel(/* dependency injection here */)
        {
        }
        public FeedBackViewModel(FeedbackContext dbFeedback)
        {
            db = dbFeedback;
        }

        public override string Title { get { return "View model title"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        
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
