namespace C2_PortfolioTreePrinter_Exercise.Logic
{
    public class InvestmentNet
    {
        private readonly ReceptiveAccount _account;

        public InvestmentNet(ReceptiveAccount account) => _account = account;

        public double Total()
        {
            var investmentNet = 0.0;

            foreach (var transaction in _account.transactions())
            {
                investmentNet = transaction.applyInvestmentTo(investmentNet);
            }

            return investmentNet;
        }
    }
}