namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class TransferDeposit : TransferLeg
    {
        private readonly Transfer _transfer;

        public TransferDeposit(Transfer transfer) => _transfer = transfer;

        public double Value() => _transfer.Value();

        public void Accept(AccountTransactionVisitor visitor) =>
            visitor.VisitTransferDeposit(this);

        public Transfer Transfer() => _transfer;
    }
}