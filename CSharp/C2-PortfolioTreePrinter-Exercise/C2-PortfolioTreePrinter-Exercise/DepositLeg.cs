using System.Diagnostics;

namespace C2_PortfolioTreePrinter_Exercise
{
    [DebuggerDisplay("Transferencia por {value()}")]
    internal class DepositLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public DepositLeg(Transfer transfer, ReceptiveAccount toAccount)
        {
            _transfer = transfer;
            toAccount.register(this);
        }

        public double applyTo(double balance) => balance + value();

        public string Humanize() => $"Transferencia por {value():F1}";

        public Transfer transfer() => _transfer;

        public double value() => _transfer.value();

        public double applyTo(Classificator classificator, double balance) =>
            classificator.applyTo(this, balance);
    }
}