namespace PortfolioTreePrinter_Exercise.Logic
{
    public class InvestmentNet : Classificator
    {
        public InvestmentNet(ReceptiveAccount account) : base(account)
        {
        }

        public override double applyTo(CertificateOfDeposit certificateOfDeposit, double balance) =>
            balance + certificateOfDeposit.value();
    }
}