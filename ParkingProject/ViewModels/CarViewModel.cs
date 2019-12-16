namespace ParkingProject.ViewModels
{
    using Catel.MVVM;
    using Catel.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ParkingProject.Models;
    using Catel.Data;

    public class CarViewModel : ViewModelBase
    {
        [Model]
        public Car CurrentCar
        {
            get { return GetValue<Car>(CurrentCarProperty); }
            private set { SetValue(CurrentCarProperty, value); }
        }
        public static readonly PropertyData CurrentCarProperty = RegisterProperty(nameof(CurrentCar), typeof(Car));
        
        [ViewModelToModel("CurrentCar")]
        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty(nameof(Number), typeof(string));
        
        [ViewModelToModel("CurrentCar")]
        public string Model
        {
            get { return GetValue<string>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(string));
        
        [ViewModelToModel("CurrentCar")]
        public string Color
        {
            get { return GetValue<string>(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly PropertyData ColorProperty = RegisterProperty(nameof(Color), typeof(string));

        public CarViewModel(Car car = null)
        {
            CurrentCar = car ?? new Car();
        }
    }
}
