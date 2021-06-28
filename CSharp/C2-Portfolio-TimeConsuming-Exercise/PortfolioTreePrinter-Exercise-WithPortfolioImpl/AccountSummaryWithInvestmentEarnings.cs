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
			var value = 0.0;

			var thread = new Thread(() => value = investmentEarnings.value());
			thread.Start();
            List<String> lines = summary.lines();
			thread.Join();

		    lines.Add("Ganancias por " + value);
	
		    return lines;
	    }
    }
}
