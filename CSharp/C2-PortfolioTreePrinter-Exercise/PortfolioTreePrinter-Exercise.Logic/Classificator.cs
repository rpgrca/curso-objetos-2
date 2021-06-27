namespace PortfolioTreePrinter_Exercise.Logic
{
    public class Classificator
    {
        private readonly ReceptiveAccount _account;
        private double _total = 0.0;

        public Classificator(ReceptiveAccount account) => _account = account;

        public double Compute()
        {
            foreach (var transaction in _account.transactions())
            {
                _total = transaction.applyTo(this, _total);
            }

            return _total;
        }

        public virtual double applyTo(Withdraw withdraw, double balance) => balance;

        public virtual double applyTo(Deposit deposit, double balance) => balance;

        public virtual double applyTo(DepositLeg depositLeg, double balance) => balance;

        public virtual double applyTo(WithdrawLeg withdrawLeg, double balance) => balance;

        public virtual double applyTo(CertificateOfDeposit certificateOfDeposit, double balance) => balance;
    }
}