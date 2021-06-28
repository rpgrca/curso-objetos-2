using System.Collections.Generic;
using PortfolioTreePrinter_Exercise.Logic;

namespace PortfolioTreePrinter_Exercise.UnitTests
{
    public class ReverseTreePrinterVisitor
    {
        private readonly List<string> _accountNames;

        public ReverseTreePrinterVisitor(Portfolio composedPortfolio, Dictionary<SummarizingAccount, string> accountNames)
        {
            _accountNames = new TreePrinterVisitor(composedPortfolio, accountNames).Value();
            _accountNames.Reverse();
        }

        public List<string> Value() => _accountNames;
    }
}