//Author: Kamran Zafar
//Created on: Oct 03, 2016
using LINQtoCSV;
using RiskApp.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp.Business
{
    public class Bet
    {
        public Bet()
        {

        }

        /// <summary>
        /// Returns settled bet history
        /// </summary>
        /// <returns>settled bet history</returns>
        public List<Settled> IdentifySettledBet(double rate)
        {
            try
            {
                CsvFileDescription inputFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };

                CsvContext cc = new CsvContext();

                IEnumerable<Settled> settledBets =
                    cc.Read<Settled>(@"Settled.csv", inputFileDescription);

                //var count = settledBets
                //    .GroupBy(g => g.Customer, r => r.Stake)
                //   .Select(g => new Win
                //   {
                //       Customer = g.Key,
                //       TotalBets = g.Count()
                //   })
                //   ;

                var settled =
                    from p in settledBets
                    orderby p.Customer
                    select new Settled { Customer = p.Customer, Event = p.Event, Participant = p.Participant, Stake = p.Stake, Win = p.Win }
                    ;

                return GetSettledUnusualBet(settled.ToList(), rate);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// This method will return bets containing customers bet hiostory winning at unusual rate
        /// </summary>
        /// <param name="settledBets"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public List<Settled> GetSettledUnusualBet(List<Settled> settledBets, double rate)
        {
            List<int> unUsualCustomers = new List<int>();
            var uniqueCustomers = settledBets.Select(x => x.Customer).Distinct();
            foreach (var uniqueCustomer in uniqueCustomers)
            {
                double totalBets = settledBets.Where(x => x.Customer == uniqueCustomer).Count();
                double totalBetsWin = settledBets.Where(x => x.Customer == uniqueCustomer && x.Win > 0).Count();

                if (totalBetsWin / totalBets > rate)
                {
                    unUsualCustomers.Add(uniqueCustomer);
                }
            }

            settledBets = settledBets.Where(x => unUsualCustomers.Contains(x.Customer)).ToList<Settled>();

            return settledBets;
        }

        /// <summary>
        /// Returns Unsettled bet history
        /// </summary>
        /// <returns>Unsettled bet history</returns>
        public List<UnSettled> IdentifyUnSettledBet()
        {
            try
            {
                CsvFileDescription inputFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };

                CsvContext cc = new CsvContext();

                IEnumerable<UnSettled> unSettledBets =
                    cc.Read<UnSettled>(@"UnSettled.csv", inputFileDescription);

                var average = unSettledBets
                    .GroupBy(g => g.Customer, r => r.Stake)
                   .Select(g => new AverageBet
                   {
                       Customer = g.Key,
                       AverageStake = g.Average()
                   })
                   ;

                var bets =
                    from p in unSettledBets
                    orderby p.Customer
                    select new UnSettled
                    {
                        Customer = p.Customer,
                        Event = p.Event,
                        Participant = p.Participant,
                        Stake = p.Stake,
                        ToWin = p.ToWin
                        //,ListAverageBet = average.ToList()
                        ,AverageStake = average.Where(x => x.Customer == p.Customer).Select(x => x.AverageStake).FirstOrDefault()
                    };

                return bets.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
