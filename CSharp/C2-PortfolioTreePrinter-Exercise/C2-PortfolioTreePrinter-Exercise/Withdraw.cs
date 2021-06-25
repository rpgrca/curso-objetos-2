﻿namespace C2_PortfolioTreePrinter_Exercise
{
    internal class Withdraw : AccountTransaction
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

        public string Humanize() => $"Extracción por {value():F1}";
    }
}
