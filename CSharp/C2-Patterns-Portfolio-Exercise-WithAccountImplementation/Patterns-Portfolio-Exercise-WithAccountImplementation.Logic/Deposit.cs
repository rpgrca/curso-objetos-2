namespace Patterns_Portfolio_Exercise_WithAccountImplementation.Logic
{
    public class Deposit: AccountTransaction
    {
        private readonly double m_value;

        public static Deposit registerForOn(double value, ReceptiveAccount account)
        {
            var deposit = new Deposit(value);
            account.register(deposit);

            return deposit;
        }

        public Deposit(double value) => m_value = value;

        public double value() => m_value;
    }
}