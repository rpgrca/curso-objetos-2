namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface TransferLeg: AccountTransaction
    {
        Transfer transfer();
    }

    internal class DepositLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public DepositLeg(Transfer transfer)
        {
            _transfer = transfer;
        }

        public double applyTo(double balance)
        {
            return balance + _transfer.value();
        }

        public Transfer transfer()
        {
            return _transfer;
        }

        public double value()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class WithdrawLeg : TransferLeg
    {
        private readonly Transfer _transfer;

        public WithdrawLeg(Transfer transfer)
        {
            _transfer = transfer;
        }

        public double applyTo(double balance)
        {
            return balance - _transfer.value();
        }

        public Transfer transfer()
        {
            return _transfer;
        }

        public double value()
        {
            throw new System.NotImplementedException();
        }
    }
}
