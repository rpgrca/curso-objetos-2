namespace C2_PortfolioTreePrinter_Exercise
{
    internal class Transfer
    {
        private readonly TransferLeg _withdrawLeg;
        private readonly TransferLeg _depositLeg;
        private readonly double _value;

        private Transfer(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount)
        {
            _value = value;
            _withdrawLeg = new WithdrawLeg(this, fromAccount);
            _depositLeg = new DepositLeg(this, toAccount);
       }

        public static Transfer registerFor(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount) =>
            new Transfer(value, fromAccount, toAccount);

        public double value() => _value;

        public TransferLeg depositLeg() => _depositLeg;

        public TransferLeg withdrawLeg() => _withdrawLeg;
    }
}
