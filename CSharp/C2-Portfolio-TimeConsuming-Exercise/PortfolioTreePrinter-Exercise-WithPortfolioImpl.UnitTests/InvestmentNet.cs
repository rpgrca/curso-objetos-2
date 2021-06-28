namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class InvestmentNet: AccountTransactionVisitor 
    {
        private SummarizingAccount account;
        private double m_value;

        public InvestmentNet(SummarizingAccount account) {
            this.account = account;
        }

        public double value()
        {
            System.Threading.Thread.Sleep(1200);

            m_value = 0.0;
            account.acceptTransactionsVisitor(this);
            return m_value;
        }

        public void visitCertificateOfDeposit(
                CertificateOfDeposit certificateOfDeposit) {
            m_value += certificateOfDeposit.value();
        }

        public void visitDeposit(Deposit deposit) {
        }

        public void visitWithdraw(Withdraw withdraw) {
        }

        public void visitTransferDeposit(TransferDeposit transferDeposit) {
        }

        public void visitTransferWithdraw(TransferWithdraw transferWithdraw) {
        }
    }
}