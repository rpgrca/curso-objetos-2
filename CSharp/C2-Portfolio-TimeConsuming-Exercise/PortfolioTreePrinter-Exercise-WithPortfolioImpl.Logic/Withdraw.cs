namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Withdraw : AccountTransaction
    {
        private readonly double _value;

        public static Withdraw RegisterForOn(double value, ReceptiveAccount account)
        {
            var withdraw = new Withdraw(value);
            account.Register(withdraw);

            return withdraw;
        }

        public Withdraw(double value) => _value = value;

        public double Value() => _value;

        public void Accept(AccountTransactionVisitor visitor) => visitor.VisitWithdraw(this);
    }
}