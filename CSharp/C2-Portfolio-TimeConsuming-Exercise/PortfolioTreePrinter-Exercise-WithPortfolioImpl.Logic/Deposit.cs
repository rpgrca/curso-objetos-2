namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Deposit : AccountTransaction
    {
        private readonly double _value;

        public static Deposit RegisterForOn(double value, ReceptiveAccount account)
        {
            var deposit = new Deposit(value);
            account.Register(deposit);

            return deposit;
        }

        public Deposit(double value) => _value = value;

        public double Value() => _value;

        public void Accept(AccountTransactionVisitor visitor) => visitor.VisitDeposit(this);
    }
}