//Author: Kamran Zafar
//Created on: Oct 03, 2016
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp.ViewModel
{
    public class UnSettled
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
        public int ToWin { get; set; }

        public double AverageStake { get; set; }

        //public List<AverageBet> ListAverageBet = new List<AverageBet>();
    }

    public class AverageBet
    {
        public int Customer { get; set; }
        public double AverageStake { get; set; }
    }
}
