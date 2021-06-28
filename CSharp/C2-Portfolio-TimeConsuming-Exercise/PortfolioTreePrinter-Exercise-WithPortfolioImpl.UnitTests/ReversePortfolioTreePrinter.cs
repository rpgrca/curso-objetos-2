using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class ReversePortfolioTreePrinter
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
