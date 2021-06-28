namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class BalanceVisitor: AccountTransactionVisitor
    {
        private double m_value;
        private readonly ReceptiveAccount account;

        public BalanceVisitor(ReceptiveAccount account) {
            this.account = account;
        }

        public double value (){
            m_value = 0;
            account.acceptTransactionsVisitor(this);
            return m_value;
        }

        public void visitDeposit(Deposit deposit) {
            m_value += deposit.value();
        }

        public void visitWithdraw(Withdraw withdraw) {
            m_value -= withdraw.value();
        }

        public void visitCertificateOfDeposit(
                CertificateOfDeposit certificateOfDeposit) {
            m_value -= certificateOfDeposit.value();
        }

        public void visitTransferDeposit(TransferDeposit transferDeposit) {
            m_value += transferDeposit.value();
        }

        public void visitTransferWithdraw(TransferWithdraw transferWithdraw) {
            m_value -= transferWithdraw.value();
        }
    }
}