using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class ReversePortfolioTreePrinter
    {
        private PortfolioTreePrinter printer;

        public ReversePortfolioTreePrinter(Portfolio portfolio,
                    Dictionary<SummarizingAccount, String> accountNames)
        {
            printer = new PortfolioTreePrinter(portfolio, accountNames);
        }

        public List<String> lines()
        {
            List<String> lines = printer.lines();
            lines.Reverse();

            return lines;
        }
    }
}