namespace ParkingProject.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using ParkingProject.Models;
    using System.Threading.Tasks;

    public class SignInViewModel : ViewModelBase
    {
        public SignInViewModel(/* dependency injection here */)
        {
        }

        public override string Title { get { return "Sign In"; } }


        [Model]
        public User UserObject
        {
            get { return GetValue<User>(UserObjectProperty); }
            private set { SetValue(UserObjectProperty, value); }
        }

        public static readonly PropertyData UserObjectProperty = RegisterProperty(nameof(UserObject), typeof(User));


        [ViewModelToModel("UserObject", "Login")]
        public string UserLogin
        {
            get { return GetValue<string>(UserLoginProperty); }
            set { SetValue(UserLoginProperty, value); }
        }
        public static readonly PropertyData UserLoginProperty = RegisterProperty(nameof(UserLogin), typeof(string));
        
        [ViewModelToModel("UserObject", "Pass")]
        public string UserPass
        {
            get { return GetValue<string>(UserPassProperty); }
            set { SetValue(UserPassProperty, value); }
        }

        public static readonly PropertyData UserPassProperty = RegisterProperty(nameof(UserPass), typeof(string));

        public Command SignIn
        {
            get
            {
                return new Command(() =>
                {
                    //CheckPass();
                });
            }
        }
        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        //private async void CheckPass()
        //{
        //    if (Login == "Login" && Pass == "Password")
        //        await base.CloseAsync();
        //}

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

        public SignInViewModel(User user= null)
        {
            UserObject = user ?? new User();
        }

    }
}
