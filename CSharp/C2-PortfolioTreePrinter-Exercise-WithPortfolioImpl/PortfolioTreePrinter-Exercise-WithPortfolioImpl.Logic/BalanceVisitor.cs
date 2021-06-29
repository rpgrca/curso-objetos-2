namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class BalanceVisitor : AccountTransactionVisitor
    {
        private double _value;
        private readonly ReceptiveAccount _account;

        public BalanceVisitor(ReceptiveAccount account) =>
            _account = account;

        public double Value()
        {
            _value = 0;
            _account.Accept(this);
            return _value;
        }

        public void VisitDeposit(Deposit deposit) =>
            _value += deposit.Value();

        public void VisitWithdraw(Withdraw withdraw) =>
            _value -= withdraw.Value();

        public void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit) =>
            _value -= certificateOfDeposit.Value();

        public void VisitTransferDeposit(TransferDeposit transferDeposit) =>
            _value += transferDeposit.Value();

        public void VisitTransferWithdraw(TransferWithdraw transferWithdraw) =>
            _value -= transferWithdraw.Value();
    }
}