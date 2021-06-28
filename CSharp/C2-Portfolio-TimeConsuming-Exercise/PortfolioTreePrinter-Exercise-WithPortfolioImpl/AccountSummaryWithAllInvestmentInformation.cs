using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class AccountSummaryWithAllInvestmentInformation
    {
	    private SummarizingAccount account;

	    public AccountSummaryWithAllInvestmentInformation(SummarizingAccount account) {
		    this.account = account;
	    }

	    public List<String> lines() {
		    AccountSummaryWithInvestmentEarnings summary = new AccountSummaryWithInvestmentEarnings(account);
		    InvestmentNet investmentNet = new InvestmentNet(account);
     		var value = 0.0;

			var thread = new Thread(() => value = investmentNet.value());
			thread.Start();
            List<String> lines = summary.lines();
			thread.Join();
            lines.Add("Inversiones por " + value);
	
		    return lines;
	    }
    }
}
