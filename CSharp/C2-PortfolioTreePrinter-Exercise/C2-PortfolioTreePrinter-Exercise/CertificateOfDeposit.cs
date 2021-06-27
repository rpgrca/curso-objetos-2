using System.Diagnostics;

namespace C2_PortfolioTreePrinter_Exercise
{
    [DebuggerDisplay("Plazo fijo por {value()} durante {numberOfDays()} días a una tna de {tna()}")]
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

        public double earnings() => _value * (_tna / 360) * _numberOfDays;

        public int numberOfDays() => _numberOfDays;

        public double tna() => _tna;

        public double applyTo(double balance) => balance + earnings();

        public string Humanize() => $"Plazo fijo por {value():F1} durante {numberOfDays()} días a una tna de {tna():F1}";

        public double applyTo(Classificator classificator, double balance) => classificator.applyTo(this, balance);
    }
}