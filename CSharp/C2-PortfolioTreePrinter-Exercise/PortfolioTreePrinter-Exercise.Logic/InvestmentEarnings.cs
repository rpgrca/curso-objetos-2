namespace PortfolioTreePrinter_Exercise.Logic
{
    public class InvestmentEarnings : Classificator
    {
        public InvestmentEarnings(ReceptiveAccount account) : base(account)
        {
        }

        public override double applyTo(CertificateOfDeposit certificateOfDeposit, double balance) =>
            balance + certificateOfDeposit.earnings();
    }
}