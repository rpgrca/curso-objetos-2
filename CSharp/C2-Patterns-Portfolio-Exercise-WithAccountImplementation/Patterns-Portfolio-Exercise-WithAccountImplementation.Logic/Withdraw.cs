namespace Patterns_Portfolio_Exercise_WithAccountImplementation.Logic
{
    public class Withdraw : AccountTransaction
    {
        private readonly double _value;

        public static Withdraw registerForOn(double value, ReceptiveAccount account)
        {
            var withdraw = new Withdraw(value);
            account.register(withdraw);

            return withdraw;
        }

        public Withdraw(double value) => _value = value;

        public double value() => _value;
    }
}