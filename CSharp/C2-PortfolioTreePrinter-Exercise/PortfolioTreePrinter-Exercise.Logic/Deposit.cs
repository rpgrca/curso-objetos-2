using System.Diagnostics;

namespace PortfolioTreePrinter_Exercise.Logic
{
    [DebuggerDisplay("Depósito por {value()}")]
    public class Deposit : AccountTransaction
    {
        private readonly double _value;

        public static Deposit registerForOn(double value, ReceptiveAccount account)
        {
            var deposit = new Deposit(value);
            account.register(deposit);

            return deposit;
        }

        public Deposit(double value) => _value = value;

        public double value() => _value;

        public double applyTo(double balance) => balance + _value;

        public string Humanize() => $"Depósito por {value():F1}";

        public double applyTo(Classificator classificator, double balance) =>
            classificator.applyTo(this, balance);
    }
}