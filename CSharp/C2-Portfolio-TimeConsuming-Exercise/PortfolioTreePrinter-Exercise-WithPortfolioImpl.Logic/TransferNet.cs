namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class TransferNet: AccountTransactionVisitor
    {
        private SummarizingAccount account;
        private double m_value;

        public TransferNet(SummarizingAccount account)
        {
            this.account = account;
        }

        public double value(){
            m_value = 0.0;

            account.acceptTransactionsVisitor(this);

            return m_value;
        }

        public void visitDeposit(Deposit deposit)
        {
        }

        public void visitWithdraw(Withdraw withdraw)
        {
        }

        public void visitCertificateOfDeposit(
                CertificateOfDeposit certificateOfDeposit) {
        }

        public void visitTransferDeposit(TransferDeposit transferDeposit) {
            m_value += transferDeposit.value();
        }

        public void visitTransferWithdraw(TransferWithdraw transferWithdraw) {
            m_value -= transferWithdraw.value();
        }
    }
}