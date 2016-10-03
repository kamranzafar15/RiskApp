using RiskApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bet obj = new Bet();

            obj.IdentifySettledBet();

            obj.IdentifyUnSettledBet();
        }
    }
}
