using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    class Place:ModelBase
    {
        public int Number
        {
            get { return GetValue<int>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty(nameof(Number), typeof(int), null);

        public bool IsEmpty
        {
            get { return GetValue<bool>(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }
        public static readonly PropertyData IsEmptyProperty = RegisterProperty(nameof(IsEmpty), typeof(bool), true);

    }
}
