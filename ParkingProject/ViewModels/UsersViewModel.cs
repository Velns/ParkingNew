namespace ParkingProject.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Catel.Services;
    using System.Threading.Tasks;
    using ParkingProject.Models; 

    public class UsersViewModel : ViewModelBase
    {        
       // User testUser = new User();

        public UsersViewModel(User user = null)
        {
            CurUser = user ?? new User();
        }
        
        [Model]
        public User CurUser
        {
            get { return GetValue<User>(CurUserProperty); }
            private set { SetValue(CurUserProperty, value); }
        }
        public static readonly PropertyData CurUserProperty = RegisterProperty(nameof(CurUser), typeof(User));

        [ViewModelToModel("CurUser","Name")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel(nameof(CurUser))]
        public string PhoneNum
        {
            get { return GetValue<string>(PhoneNumProperty); }
            set { SetValue(PhoneNumProperty, value); }
        }
        public static readonly PropertyData PhoneNumProperty = RegisterProperty(nameof(PhoneNum), typeof(string));

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }
        protected override async Task CloseAsync()
        {
            await base.CloseAsync();
        }

        //public Command ShowName
        //{
        //    get
        //    {
        //        return new Command( () => 
        //        {_messageService.ShowAsync( CurUser.PhoneNum);
        //        });
        //    }
        //}

    }
}
