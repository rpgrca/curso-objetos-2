using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class PortfolioTreePrinter : SummarizingAccountVisitor
    {
        private readonly Portfolio _portfolio;
        private readonly Dictionary<SummarizingAccount, string> _accountNames;
        private List<string> _lines;
        private int _spaces;

        public PortfolioTreePrinter(Portfolio portfolio, Dictionary<SummarizingAccount, string> accountNames) =>
            (_portfolio, _accountNames) = (portfolio, accountNames);

        public List<string> Lines()
        {
            _lines = new List<string>();
            _spaces = 0;
            _portfolio.Accept(this);

            return _lines;
        }

        public void VisitPortfolio(Portfolio portfolio)
        {
            LineFor(portfolio);
            _spaces++;
            portfolio.visitAccountsWith(this);
            _spaces--;
        }

        private void LineFor(SummarizingAccount summarizingAccount)
        {
            var line = string.Empty;

            for (var i = 0; i < _spaces; i++)
            {
                line += " ";
            }

            _accountNames.TryGetValue(summarizingAccount, out string name);
            line += name;
            _lines.Add(line);
        }

        public void VisitReceptiveAccount(ReceptiveAccount receptiveAccount) =>
            LineFor(receptiveAccount);
    }
}