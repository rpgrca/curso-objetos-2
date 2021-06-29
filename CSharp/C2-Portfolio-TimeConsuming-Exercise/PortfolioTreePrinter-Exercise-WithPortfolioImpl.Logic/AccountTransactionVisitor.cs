namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface AccountTransactionVisitor
    {
        void VisitDeposit(Deposit deposit);
        void VisitTransferDeposit(TransferDeposit transferDeposit);
        void VisitTransferWithdraw(TransferWithdraw transferWithdraw);
        void VisitWithdraw(Withdraw withdraw);
        void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit);
    }
}