using System.Collections.Generic;
using System.Linq;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class Summary
    {
        private readonly ReceptiveAccount _fromAccount;

        public Summary(ReceptiveAccount fromAccount) => _fromAccount = fromAccount;

        public List<string> Lines()
        {
            return _fromAccount.transactions().Aggregate(new List<string>(),
                (agg, trn) => {
                    agg.Add(trn.Humanize());
                    return agg;
                });
        }
    }
}
