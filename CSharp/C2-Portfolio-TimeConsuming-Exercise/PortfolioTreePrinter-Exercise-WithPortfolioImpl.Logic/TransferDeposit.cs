namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class TransferDeposit : TransferLeg
    {
        private Transfer m_transfer;

        public TransferDeposit(Transfer transfer)
        {
            m_transfer = transfer;
        }

        public double value()
        {
            return m_transfer.value();
        }

        public void accept(AccountTransactionVisitor visitor)
        {
            visitor.visitTransferDeposit(this);
        }

        public Transfer transfer()
        {
            return m_transfer;
        }
    }
}