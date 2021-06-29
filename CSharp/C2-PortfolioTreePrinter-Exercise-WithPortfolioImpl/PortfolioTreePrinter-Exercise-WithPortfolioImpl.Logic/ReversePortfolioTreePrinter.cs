using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class ReversePortfolioTreePrinter
    {
        private readonly PortfolioTreePrinter _printer;

        public ReversePortfolioTreePrinter(Portfolio portfolio, Dictionary<SummarizingAccount, string> accountNames) =>
            _printer = new PortfolioTreePrinter(portfolio, accountNames);

        public List<string> Lines()
        {
            var lines = _printer.Lines();
            lines.Reverse();

            return lines;
        }
    }
}