namespace C2_PortfolioTreePrinter_Exercise
{
    internal class InvestmentNet : Classificator
    {
        private readonly ReceptiveAccount _account;
        private double _investmentNet = 0.0;

        public InvestmentNet(ReceptiveAccount account) => _account = account;

        public double Compute()
        {
            foreach (var transaction in _account.transactions())
            {
                _investmentNet = transaction.applyTo(this, _investmentNet);
            }

            return _investmentNet;
        }

        public override double applyTo(CertificateOfDeposit certificateOfDeposit, double balance) =>
            balance + certificateOfDeposit.value();
    }
}