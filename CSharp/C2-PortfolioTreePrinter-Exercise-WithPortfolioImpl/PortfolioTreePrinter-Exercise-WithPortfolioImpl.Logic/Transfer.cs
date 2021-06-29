namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Transfer
    {
        private readonly double _value;
        private readonly TransferDeposit _depositLeg;
        private readonly TransferWithdraw _withdrawLeg;

        public Transfer(double value) =>
            (_value, _depositLeg, _withdrawLeg) =
                (value, new TransferDeposit(this), new TransferWithdraw(this));

        public static Transfer RegisterFor(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount)
        {
            var transfer = new Transfer(value);
            fromAccount.Register(transfer.WithdrawLeg());
            toAccount.Register(transfer.DepositLeg());

            return transfer;
        }

        public double Value() => _value;

        public TransferLeg WithdrawLeg() => _withdrawLeg;

        public TransferLeg DepositLeg() => _depositLeg;
    }
}