namespace C2_PortfolioTreePrinter_Exercise
{
    internal class InvestmentEarnings : Classificator
    {
        private readonly ReceptiveAccount _account;
        private double _investmentEarnings = 0.0;

        public InvestmentEarnings(ReceptiveAccount account) => _account = account;

        public double Compute()
        {
            foreach (var transaction in _account.transactions())
            {
                _investmentEarnings = transaction.applyTo(this, _investmentEarnings);
            }

            return _investmentEarnings;
        }

        public override double applyTo(CertificateOfDeposit certificateOfDeposit, double balance) =>
            balance + certificateOfDeposit.earnings();
    }
}