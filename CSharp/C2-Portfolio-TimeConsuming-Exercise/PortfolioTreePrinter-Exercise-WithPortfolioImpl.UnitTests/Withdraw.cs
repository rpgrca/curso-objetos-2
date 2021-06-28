namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class Withdraw: AccountTransaction
    {
	    private double m_value;

	    public static Withdraw registerForOn(double value, ReceptiveAccount account) {
		    Withdraw withdraw = new Withdraw(value);
		    account.register(withdraw);

		    return withdraw;
	    }

	    public Withdraw (double value) {
		    m_value = value;
	    }

	    public double value() {
		    return m_value;
	    }

        public void accept(AccountTransactionVisitor visitor)
        {
            visitor.visitWithdraw(this);
        }
    }
}