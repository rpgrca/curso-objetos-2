namespace PortfolioTreePrinter_Exercise.Logic
{
    public class WithdrawLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public WithdrawLeg(Transfer transfer, ReceptiveAccount fromAccount)
        {
            _transfer = transfer;
            fromAccount.register(this);
        }

        public double applyTo(double balance) => balance - value();

        public string Humanize() => $"Transferencia por -{value():F1}";

        public Transfer transfer() => _transfer;

        public double value() => _transfer.value();

        public double applyTransferTo(double balance) => applyTo(balance);

        public double applyInvestmentTo(double balance) => balance;

        public double applyInvestmentEarningsTo(double balance) => balance;
    }
}
