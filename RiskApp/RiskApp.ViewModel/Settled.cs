using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp.ViewModel
{
    public class Settled
    {
        [CsvColumn(Name = "Customer", FieldIndex = 1)]
        public int Customer { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public int Event { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public int Participant { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public int Stake { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public int Win { get; set; }

        public int TotalBets { get; set; }
        public int WinBets { get; set; }
    }
}
