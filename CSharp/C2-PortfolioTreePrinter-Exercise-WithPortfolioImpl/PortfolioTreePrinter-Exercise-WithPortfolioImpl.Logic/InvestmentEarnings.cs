namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class InvestmentEarnings : AccountTransactionVisitor
    {
        private readonly SummarizingAccount _account;
        private double _value;

        public InvestmentEarnings(SummarizingAccount account) =>
            _account = account;

        public double Value()
        {
            //System.Threading.Thread.Sleep(1200);

            _value = 0.0;
            _account.Accept(this);
            return _value;
        }

        public void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit) =>
            _value += certificateOfDeposit.Earnings();

        public void VisitDeposit(Deposit deposit)
        {
        }

        public void VisitWithdraw(Withdraw withdraw)
        {
        }

        public void VisitTransferDeposit(TransferDeposit transferDeposit)
        {
        }

        public void VisitTransferWithdraw(TransferWithdraw transferWithdraw)
        {
        }
    }
}