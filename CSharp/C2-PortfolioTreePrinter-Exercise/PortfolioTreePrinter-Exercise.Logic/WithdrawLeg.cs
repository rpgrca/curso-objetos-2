using System.Diagnostics;

namespace PortfolioTreePrinter_Exercise.Logic
{
    [DebuggerDisplay("Transferencia por -{value()}")]
    public class WithdrawLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public WithdrawLeg(Transfer transfer, ReceptiveAccount fromAccount)
        {
            _transfer = transfer;
            fromAccount.register(this);
        }

        public double applyTo(double balance) => balance - value();

        public Transfer transfer() => _transfer;

        public double value() => _transfer.value();

        public void accept(TransactionVisitor visitor) => visitor.visit(this);
    }
}
