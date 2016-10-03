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
        public List<Settled> IdentifySettledBet()
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
                    select new Settled { Customer = p.Customer, Event = p.Event, Participant = p.Participant, Stake = p.Stake, Win = p.Win };

                return settled.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns Unsettled bet history
        /// </summary>
        /// <returns>Unsettled bet history</returns>
        public ArrayList IdentifyUnSettledBet()
        {
            try
            {

            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
