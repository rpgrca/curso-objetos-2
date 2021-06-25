namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface TransferLeg: AccountTransaction
    {
        Transfer transfer();
    }

    internal class DepositLeg : Deposit, TransferLeg
    {
        private readonly Transfer _transfer;

        public DepositLeg(Transfer transfer, ReceptiveAccount toAccount)
            : base(transfer.value())
        {
            _transfer = transfer;
            toAccount.register(this);
        }

        public Transfer transfer() => _transfer;
    }

    internal class WithdrawLeg : TransferLeg
    {
        private readonly Transfer _transfer;
        private readonly Withdraw _withdraw;

        public WithdrawLeg(Transfer transfer, ReceptiveAccount fromAccount)
        {
            _transfer = transfer;
            _withdraw = new Withdraw(transfer.value());
            fromAccount.register(this);
        }

        public double applyTo(double balance) => _withdraw.applyTo(balance);

        public Transfer transfer() => _transfer;

        public double value() => _transfer.value();
    }
}
