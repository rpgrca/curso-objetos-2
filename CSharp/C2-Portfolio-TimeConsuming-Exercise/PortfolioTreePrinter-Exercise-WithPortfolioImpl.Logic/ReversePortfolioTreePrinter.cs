using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class ReversePortfolioTreePrinter
    {
        private PortfolioTreePrinter printer;

        public ReversePortfolioTreePrinter(Portfolio portfolio,
                    Dictionary<SummarizingAccount, string> accountNames)
        {
            printer = new PortfolioTreePrinter(portfolio, accountNames);
        }

        public List<string> lines()
        {
            List<string> lines = printer.lines();
            lines.Reverse();

            return lines;
        }
    }
}