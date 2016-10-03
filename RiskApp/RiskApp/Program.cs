using RiskApp.Business;
using RiskApp.ViewModel;
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
            Console.WriteLine("##### Display Settled and Unsettled bets #####");
            Bet obj = new Bet();

            List<Settled> settledBets = obj.IdentifySettledBet();

            if (settledBets != null)
            {
                Console.WriteLine("===== Settled bet history for a customer winning at an unusual rate =====");
                Console.WriteLine("Customer -   Event -   Participant -   Stake   -    Win");
                foreach (var bet in settledBets)
                {
                    Console.WriteLine(bet.Customer + "        -    " + bet.Event + "    -     " + bet.Participant + "         -      " + bet.Stake + "   -      " + bet.Win);
                }
            }
            else
            {
                Console.WriteLine("Some error occurred");
            }

            //obj.IdentifyUnSettledBet();

            Console.ReadLine();
        }
    }
}
