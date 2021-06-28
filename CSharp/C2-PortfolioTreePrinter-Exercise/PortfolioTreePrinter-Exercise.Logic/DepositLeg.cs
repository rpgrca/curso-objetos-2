using System.Diagnostics;

namespace PortfolioTreePrinter_Exercise.Logic
{
    [DebuggerDisplay("Transferencia por {value()}")]
    public class DepositLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public DepositLeg(Transfer transfer, ReceptiveAccount toAccount)
        {
            _transfer = transfer;
            toAccount.register(this);
        }

        public Transfer transfer() => _transfer;

        public double applyTo(double balance) => balance + value();

        public double value() => _transfer.value();

        public void accept(TransactionVisitor visitor) => visitor.visit(this);
    }
}