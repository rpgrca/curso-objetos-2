using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal class CertificateOfDeposit : AccountTransaction
    {
        private readonly double _value;
        private readonly int _numberOfDays;
        private readonly double _tna;

        public CertificateOfDeposit(double value, int numberOfDays, double tna)
        {
            _tna = tna;
            _numberOfDays = numberOfDays;
            _value = value;
        }

        public double value() => _value;

        public static CertificateOfDeposit registerFor(double value, int numberOfDays, double tna,
                ReceptiveAccount account)
        {
            var certificateOfDeposit = new CertificateOfDeposit(value, numberOfDays, tna);
            account.register(certificateOfDeposit);

            return certificateOfDeposit;
        }

        public double earnings()
        {
            throw new Exception();
        }

        public int numberOfDays() => _numberOfDays;

        public double tna() => _tna;

        public double applyTo(double balance) => balance - _value;

        public string Humanize()
        {
            throw new NotImplementedException();
        }

        public double applyTransferTo(double balance)
        {
            throw new NotImplementedException();
        }

        public double applyInvestmentTo(double balance) => balance + _value;
    }
}
