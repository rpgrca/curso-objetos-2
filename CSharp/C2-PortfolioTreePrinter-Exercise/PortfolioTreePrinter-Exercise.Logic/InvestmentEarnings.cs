namespace PortfolioTreePrinter_Exercise.Logic
{
    public class InvestmentEarnings : TransactionVisitor
    {
        private double _totalInvestmentEarnings;

        public InvestmentEarnings(ReceptiveAccount account) : base(account) =>
            Compute();

        public override void visit(CertificateOfDeposit certificateOfDeposit) =>
            _totalInvestmentEarnings += certificateOfDeposit.earnings();

        public double Value() => _totalInvestmentEarnings;
    }
}