using System.Diagnostics;

namespace PortfolioTreePrinter_Exercise.Logic
{
    [DebuggerDisplay("Extracción por {value()}")]
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

        public double applyTo(double balance) => balance - _value;

        public void accept(TransactionVisitor visitor) => visitor.visit(this);
    }
}
