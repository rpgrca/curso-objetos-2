using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class ReceptiveAccount: SummarizingAccount
    {

	    private IList<AccountTransaction> m_transactions = new List<AccountTransaction>();
	
	    public double balance() {
            return (new BalanceVisitor(this)).value();
	    }

	    public void register(AccountTransaction transaction) {
		    m_transactions.Add(transaction);
	    }
	
	    public bool registers(AccountTransaction transaction) {
		    return m_transactions.Contains(transaction);
	    }

	    public bool manages(SummarizingAccount account) {
		    return this == account;
	    }
	
	    public IList<AccountTransaction> transactions() {
		    return new List<AccountTransaction>(m_transactions);
	    }

        public void acceptTransactionsVisitor(AccountTransactionVisitor aVisitor)
        {
            foreach (AccountTransaction transaction in m_transactions)
                transaction.accept(aVisitor);
        }
        
        public void accept(SummarizingAccountVisitor aVisitor)
        {
            aVisitor.visitReceptiveAccount(this);
        }


    }
}
