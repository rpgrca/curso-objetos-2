namespace C2_PortfolioTreePrinter_Exercise
{
    internal class InvestmentEarnings
    {
        private readonly ReceptiveAccount _account;

        public InvestmentEarnings(ReceptiveAccount account) => _account = account;

        public double Total()
        {
            var investmentEarnings = 0.0;

            foreach (var transaction in _account.transactions())
            {
                investmentEarnings = transaction.applyInvestmentEarningsTo(investmentEarnings);
            }

            return investmentEarnings;
        }
    }
}