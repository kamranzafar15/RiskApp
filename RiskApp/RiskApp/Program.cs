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
            double rate = 0.6;
            List<Settled> settledBets = obj.IdentifySettledBet(rate);

            //List<int> unUsualCustomers = new List<int>();
            //var uniqueCustomers = settledBets.Select(x => x.Customer).Distinct();
            //foreach (var uniqueCustomer in uniqueCustomers)
            //{
            //    double totalBets = settledBets.Where(x => x.Customer == uniqueCustomer).Count();
            //    double totalBetsWin = settledBets.Where(x => x.Customer == uniqueCustomer && x.Win > 0).Count();

            //    if (totalBetsWin / totalBets > 0.6)
            //    {
            //        unUsualCustomers.Add(uniqueCustomer);
            //    }
            //}

            //settledBets = settledBets.Where(x => unUsualCustomers.Contains(x.Customer)).ToList<Settled>();
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

            //===============================================================
            List<UnSettled> unSettledBets = obj.IdentifyUnSettledBet();
            if (unSettledBets != null)
            {
                Console.WriteLine("Customer - Stake");
                foreach (var bet in unSettledBets)
                {
                    Console.WriteLine(bet.Customer + "        -   " + bet.Stake);
                }
            }
            else
            {
                Console.WriteLine("Some error occurred");
            }

            Console.ReadLine();
        }
    }
}
