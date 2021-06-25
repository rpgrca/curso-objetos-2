using System;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal class Transfer
    {
        private readonly TransferLeg _withdrawLeg;
        private readonly TransferLeg _depositLeg;
        private readonly double _value;

        public Transfer(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount)
        {
            _value = value;
            _withdrawLeg = new WithdrawLeg(this);
            _depositLeg = new DepositLeg(this);
        }

        public static Transfer registerFor(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount)
        {
            var transfer = new Transfer(value, fromAccount, toAccount);
            toAccount.register(transfer.depositLeg());
            fromAccount.register(transfer.withdrawLeg());
            return transfer;
        }

        public double value() => _value;

        public TransferLeg depositLeg() => _depositLeg;

        public TransferLeg withdrawLeg() => _withdrawLeg;
    }
}
