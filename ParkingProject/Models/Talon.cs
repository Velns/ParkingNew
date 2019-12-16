using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    public class Talon : ValidatableModelBase
    {
        public int ID { set; get; }

        public string Parking
        {
            get { return GetValue<string>(ParkingProperty); }
            set { SetValue(ParkingProperty, value); }
        }
        public static readonly PropertyData ParkingProperty = RegisterProperty(nameof(Parking), typeof(string), null);
        
        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty(nameof(Number), typeof(string), null);
        
        public int Place
        {
            get { return GetValue<int>(PlaceProperty); }
            set { SetValue(PlaceProperty, value); }
        }
        public static readonly PropertyData PlaceProperty = RegisterProperty(nameof(Place), typeof(int), null);
        
        public string CarNumber
        {
            get { return GetValue<string>(CarNumberProperty); }
            set { SetValue(CarNumberProperty, value); }
        }
        public static readonly PropertyData CarNumberProperty = RegisterProperty(nameof(CarNumber), typeof(string), null);

        public string StartDate
        {
            get { return GetValue<string>(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }
        public static readonly PropertyData StartDateProperty = RegisterProperty(nameof(StartDate), typeof(string), null);
        
        public string StopDate
        {
            get { return GetValue<string>(StopDateProperty); }
            set { SetValue(StopDateProperty, value); }
        }
        public static readonly PropertyData StopDateProperty = RegisterProperty(nameof(StopDate), typeof(string), null);

        //public DateTime StartDate
        //{
        //    get { return GetValue<DateTime>(StartDateProperty); }
        //    set { SetValue(StartDateProperty, value); }
        //}
        //public static readonly PropertyData StartDateProperty = RegisterProperty(nameof(StartDate), typeof(DateTime), null);

        //public DateTime StopDate
        //{
        //    get { return GetValue<DateTime>(StopDateProperty); }
        //    set { SetValue(StopDateProperty, value); }
        //}
        //public static readonly PropertyData StopDateProperty = RegisterProperty(nameof(StopDate), typeof(DateTime), null);
    }
}
