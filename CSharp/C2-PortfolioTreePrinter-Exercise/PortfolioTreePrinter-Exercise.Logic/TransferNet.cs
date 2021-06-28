namespace PortfolioTreePrinter_Exercise.Logic
{
    public class TransferNet : TransactionVisitor
    {
        private double _totalTransferNet;

        public TransferNet(ReceptiveAccount account) : base(account) =>
            Compute();

        public override void visit(DepositLeg depositLeg) =>
            _totalTransferNet += depositLeg.value();

        public override void visit(WithdrawLeg withdrawLeg) =>
            _totalTransferNet -= withdrawLeg.value();

        public double Value() => _totalTransferNet;
    }
}