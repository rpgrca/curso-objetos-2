namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class CertificateOfDeposit:AccountTransaction
    {
	    private double m_value;
	    private int m_numberOfDays;
	    private double m_tna;

	    public CertificateOfDeposit(double value, int numberOfDays, double tna) {
				    m_value = value;
				    m_numberOfDays = numberOfDays;
				    m_tna = tna;
				      }

	    public double value() {
		    return m_value;
	    }

	    public static CertificateOfDeposit registerFor(double value, int numberOfDays, double tna,
			    ReceptiveAccount account) {
		    CertificateOfDeposit certificateOfDeposit = new CertificateOfDeposit(value,numberOfDays,
				    tna);
		    account.register(certificateOfDeposit);
		    return certificateOfDeposit;
	    }

	    public double earnings() {
            return m_value*m_tna/360*m_numberOfDays;
	    }

	    public int numberOfDays() {
		    return m_numberOfDays;
	    }

	    public double tna() {
		    return m_tna;
	    }

        public void accept(AccountTransactionVisitor visitor)
        {
            visitor.visitCertificateOfDeposit(this);
        }
    }
}