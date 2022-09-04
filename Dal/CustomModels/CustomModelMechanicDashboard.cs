using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.CustomModels
{
    public class CustomModelMechanicDashboard
    {
        public IEnumerable<FirstTableData> FirstTableData { get; set;}
        public IEnumerable<SecondTableData> SecondTableData { get; set; }
        public IEnumerable<ThirdTableData> ThirdTableData { get; set; }

        public int GarageCount { get; set; }
        public int Appointments { get; set; }
        public int YearIncome { get; set; }
        public int MonthIncome { get; set; }
        public int WeekIncome { get; set; }
    }
}
