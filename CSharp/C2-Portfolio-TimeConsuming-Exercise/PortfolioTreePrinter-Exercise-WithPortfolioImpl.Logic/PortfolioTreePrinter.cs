using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class PortfolioTreePrinter : SummarizingAccountVisitor
    {
         private Portfolio portfolio;
        private Dictionary<SummarizingAccount, string> accountNames;
        private List<string> m_lines;
        private int spaces;

        public PortfolioTreePrinter(Portfolio portfolio,
                Dictionary<SummarizingAccount, string> accountNames) {
            this.portfolio = portfolio;
            this.accountNames = accountNames;
        }

        public List<string> lines() {
            m_lines = new List<string>();
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
            string line = "";
            string name;

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