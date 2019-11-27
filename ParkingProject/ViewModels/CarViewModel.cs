namespace Parking.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    using Parking.Models;
    using Catel.Data;

    public class CarViewModel : ViewModelBase
    {

        [Model]
        public Car CarObject
        {
            get { return GetValue<Car>(CarObjectProperty); }
            private set { SetValue(CarObjectProperty, value); }
        }
        public static readonly PropertyData CarObjectProperty = RegisterProperty(nameof(CarObject), typeof(Car));
        
        [ViewModelToModel("CarObject", "Number")]
        public string CarNumber
        {
            get { return GetValue<string>(CarNumberProperty); }
            set { SetValue(CarNumberProperty, value); }
        }
        public static readonly PropertyData CarNumberProperty = RegisterProperty(nameof(CarNumber), typeof(string));


        [ViewModelToModel("CarObject", "Model")]
        public string CarModel
        {
            get { return GetValue<string>(CarModelProperty); }
            set { SetValue(CarModelProperty, value); }
        }
        public static readonly PropertyData CarModelProperty = RegisterProperty(nameof(CarModel), typeof(string));


        [ViewModelToModel("CarObject", "Color")]
        public string CarColor
        {
            get { return GetValue<string>(CarColorProperty); }
            set { SetValue(CarColorProperty, value); }
        }
        public static readonly PropertyData CarColorProperty = RegisterProperty(nameof(CarColor), typeof(string));

        public CarViewModel(Car car = null)
        {
            CarObject = car ?? new Car();
        }
    }
}
