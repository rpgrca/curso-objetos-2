namespace PortfolioTreePrinter_Exercise.Logic
{
    public class TransferNet : Classificator
    {
        private readonly ReceptiveAccount _account;
        private double _transferNet = 0.0;

        public TransferNet(ReceptiveAccount account) => _account = account;

        public double Compute()
        {
            foreach (var transaction in _account.transactions())
            {
                _transferNet = transaction.applyTo(this, _transferNet);
            }

            return _transferNet;
        }

        public override double applyTo(DepositLeg depositLeg, double balance) =>
            depositLeg.applyTo(balance);

        public override double applyTo(WithdrawLeg withdrawLeg, double balance) =>
            withdrawLeg.applyTo(balance);
    }
}