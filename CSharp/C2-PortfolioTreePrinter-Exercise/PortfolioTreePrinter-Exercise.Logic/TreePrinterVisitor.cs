using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class TreePrinterVisitor
    {
        private readonly Portfolio _composedPortfolio;
        private readonly Dictionary<SummarizingAccount, string> _accountNames;
        private readonly List<string> _tree;

        public TreePrinterVisitor(Portfolio composedPortfolio, Dictionary<SummarizingAccount, string> accountNames)
        {
            _composedPortfolio = composedPortfolio;
            _accountNames = accountNames;
            _tree = new();

            Compute();
        }

        public List<string> Value() => _tree;

        public void Compute()
        {
            _composedPortfolio.visitAccounts(this);
        }

        public void visit(Portfolio portfolio)
        {
            portfolio.visitAccounts(this);
        }

        internal void visit(ReceptiveAccount receptiveAccount)
        {
            _tree.Add(_accountNames[receptiveAccount]);
        }
    }
}
