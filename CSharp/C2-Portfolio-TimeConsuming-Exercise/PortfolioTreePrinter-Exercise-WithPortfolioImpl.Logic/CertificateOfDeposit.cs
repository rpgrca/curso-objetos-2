namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class CertificateOfDeposit : AccountTransaction
    {
        private readonly double _value;
        private readonly int _numberOfDays;
        private readonly double _tna;

        public CertificateOfDeposit(double value, int numberOfDays, double tna) =>
            (_value, _numberOfDays, _tna) = (value, numberOfDays, tna);

        public double Value() => _value;

        public static CertificateOfDeposit RegisterFor(double value, int numberOfDays, double tna, ReceptiveAccount account)
        {
            var certificateOfDeposit = new CertificateOfDeposit(value, numberOfDays, tna);
            account.Register(certificateOfDeposit);

            return certificateOfDeposit;
        }

        public double Earnings() => _value * _tna / 360 * _numberOfDays;

        public int NumberOfDays() => _numberOfDays;

        public double Tna() => _tna;

        public void Accept(AccountTransactionVisitor visitor) => visitor.VisitCertificateOfDeposit(this);
    }
}