using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.CustomModels
{
    public class CustomModelAdminDashboard
    {
       public IEnumerable<FirstTableValues> FirstTableValues { get; set; }

        public IEnumerable<SecondTableValues> SecondTableValues { get; set; }

        public IEnumerable<ThirdTableValues> ThirdTableValues { get; set; }

        public int CountOfGarages { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalMechanics { get; set; }
    }
}
