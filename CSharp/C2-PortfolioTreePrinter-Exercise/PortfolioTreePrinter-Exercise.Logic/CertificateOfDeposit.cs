using System.Diagnostics;

namespace PortfolioTreePrinter_Exercise.Logic
{
    [DebuggerDisplay("Plazo fijo por {value()} durante {numberOfDays()} días a una tna de {tna()}")]
    public class CertificateOfDeposit : AccountTransaction
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

        public double applyTo(double balance) => balance - _value;

        public void accept(TransactionVisitor visitor) => visitor.visit(this);
    }
}