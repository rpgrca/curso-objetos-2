using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class PortfolioTreePrinter : SummarizingAccountVisitor
    {
 	    private Portfolio portfolio;
	    private Dictionary<SummarizingAccount, String> accountNames;
	    private List<String> m_lines;
	    private int spaces;

	    public PortfolioTreePrinter(Portfolio portfolio,
			    Dictionary<SummarizingAccount, String> accountNames) {
		    this.portfolio = portfolio;
		    this.accountNames = accountNames;
	    }

	    public List<String> lines() {
		    m_lines = new List<String>();
		    spaces = 0;

		    portfolio.accept(this);

		    return m_lines;
	    }

	    public void visitPortfolio(Portfolio portfolio) {
		    lineFor(portfolio);
		    spaces += 1;
		    portfolio.visitAccountsWith(this);
		    spaces -= 1;
	    }

	    private void lineFor(SummarizingAccount summarizingAccount) {
		    String line = "";
            String name;

		    for (int i = 0; i < spaces; i++) {
			    line = line + " ";
		    }

            accountNames.TryGetValue(summarizingAccount, out name);
            line = line + name; 
		    m_lines.Add(line);
	    }

	    public void visitReceptiveAccount(ReceptiveAccount receptiveAccount) {
		    lineFor(receptiveAccount);
	    }
    }
}