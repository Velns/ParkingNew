namespace ParkingProject.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using ParkingProject.Models;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;

    public class SignInViewModel : ViewModelBase
    {
        private bool _loginingSuccess;
        UserContext db;
        
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


        public string SignInStatus
        {
            get { return GetValue<string>(SignInStatusProperty); }
            set { SetValue(SignInStatusProperty, value); }
        }
        public static readonly PropertyData SignInStatusProperty = RegisterProperty(nameof(SignInStatus), typeof(string), null);

        public Command SignIn
        {
            get
            {
                return new Command(async () =>
                {
                    using(UserContext db = new UserContext())
                    {
                        var uLogins = db.Users.Where(u => u.Login == UserLogin && u.Pass == UserPass);
                        if (uLogins.Any())
                        {
                            SignInStatus = "* Success";
                            //await Task.Run(() => CloseAsync());
                        }
                        else SignInStatus = "* Uncorect Login or Password";
                    }                   
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
            MessageBox.Show("11111");
            await base.CloseAsync();
        }

        public SignInViewModel(/* dependency injection here */)
        {
        }
        public SignInViewModel(User user, bool isLogined, UserContext dbUser)
        {
            UserObject = user ?? new User();
            _loginingSuccess = isLogined;
            db = dbUser;
        }

    }
}
