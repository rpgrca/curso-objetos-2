namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface TransferLeg: AccountTransaction
    {
        Transfer transfer();
    }

    internal class DepositLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public DepositLeg(Transfer transfer, ReceptiveAccount toAccount)
        {
            _transfer = transfer;
            toAccount.register(this);
        }

        public double applyTo(double balance) => balance + value();

        public Transfer transfer() => _transfer;

        public double value() => _transfer.value();
    }

    internal class WithdrawLeg : TransferLeg
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
    }
}
