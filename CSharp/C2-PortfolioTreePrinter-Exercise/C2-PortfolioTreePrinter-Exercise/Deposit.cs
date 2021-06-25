using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2_PortfolioTreePrinter_Exercise
{
    class Deposit : AccountTransaction
    {

        private readonly double _value;

        public static Deposit registerForOn(double value, ReceptiveAccount account)
        {
            Deposit deposit = new Deposit(value);

            account.register(deposit);

            return deposit;
        }

        public Deposit(double value)
        {
            _value = value;

        }

        public double value()
        {
            return _value;
        }

        public double applyTo(double balance)
        {
            return balance + _value;
        }
    }
}
