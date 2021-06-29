namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class TransferNet : AccountTransactionVisitor
    {
        private readonly SummarizingAccount _account;
        private double _value;

        public TransferNet(SummarizingAccount account) => _account = account;

        public double Value()
        {
            _value = 0.0;
            _account.Accept(this);

            return _value;
        }

        public void VisitDeposit(Deposit deposit)
        {
        }

        public void VisitWithdraw(Withdraw withdraw)
        {
        }

        public void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit)
        {
        }

        public void VisitTransferDeposit(TransferDeposit transferDeposit) =>
            _value += transferDeposit.Value();

        public void VisitTransferWithdraw(TransferWithdraw transferWithdraw) =>
            _value -= transferWithdraw.Value();
    }
}