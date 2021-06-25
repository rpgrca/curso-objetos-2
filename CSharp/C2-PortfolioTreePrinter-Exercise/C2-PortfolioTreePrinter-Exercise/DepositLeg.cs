namespace C2_PortfolioTreePrinter_Exercise
{

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

        public double applyTransferTo(double balance) => applyTo(balance);

        public double applyInvestmentTo(double balance) => balance;

        public double applyInvestmentEarningsTo(double balance) => balance;
    }
}