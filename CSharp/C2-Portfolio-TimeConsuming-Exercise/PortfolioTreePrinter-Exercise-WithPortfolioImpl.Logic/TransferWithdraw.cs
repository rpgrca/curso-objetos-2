namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class TransferWithdraw : TransferLeg
    {
        private readonly Transfer _transfer;

        public TransferWithdraw(Transfer transfer) => _transfer = transfer;

        public double Value() => _transfer.Value();

        public void Accept(AccountTransactionVisitor visitor) =>
            visitor.VisitTransferWithdraw(this);

        public Transfer Transfer() => _transfer;
    }
}