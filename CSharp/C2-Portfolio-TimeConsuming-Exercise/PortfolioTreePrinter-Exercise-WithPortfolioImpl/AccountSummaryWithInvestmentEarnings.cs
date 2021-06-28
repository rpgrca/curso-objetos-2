using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class AccountSummaryWithInvestmentEarnings
    {
	    private SummarizingAccount account;

	    public AccountSummaryWithInvestmentEarnings(SummarizingAccount account) {
		    this.account = account;
	    }

	    public List<String> lines() {
		    AccountSummary summary = new AccountSummary(account);
		    InvestmentEarnings investmentEarnings = new InvestmentEarnings(account);
	       
            List<String> lines = summary.lines();
		    lines.Add("Ganancias por " + investmentEarnings.value());
	
		    return lines;
	    }
    }
}
