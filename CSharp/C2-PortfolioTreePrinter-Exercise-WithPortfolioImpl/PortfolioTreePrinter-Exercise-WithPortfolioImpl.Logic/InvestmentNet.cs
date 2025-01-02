namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class InvestmentNet : AccountTransactionVisitor
    {
        private readonly SummarizingAccount _account;
        private double _value;

        public InvestmentNet(SummarizingAccount account) =>
            _account = account;

        public double Value()
        {
            //System.Threading.Thread.Sleep(1200);

            _value = 0.0;
            _account.Accept(this);
            return _value;
        }

        public void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit) =>
            _value += certificateOfDeposit.Value();

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