using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class TreePrinterVisitor
    {
        private readonly Portfolio _composedPortfolio;
        private readonly Dictionary<SummarizingAccount, string> _accountNames;
        private readonly List<string> _tree;
        private int level;

        public TreePrinterVisitor(Portfolio composedPortfolio, Dictionary<SummarizingAccount, string> accountNames)
        {
            _composedPortfolio = composedPortfolio;
            _accountNames = accountNames;
            _tree = new();

            Compute();
        }

        public List<string> Value() => _tree;

        public void Compute() => visit(_composedPortfolio);

        public void visit(Portfolio portfolio)
        {
            _tree.Add(PrintAccountName(_accountNames[portfolio]));
            level++;
            portfolio.visitAccounts(this);
            level--;
        }

        internal void visit(ReceptiveAccount receptiveAccount)
        {
            _tree.Add(PrintAccountName(_accountNames[receptiveAccount]));
        }

        private string PrintAccountName(string accountName) => $"{new string(' ', level)}{accountName}";
    }
}
