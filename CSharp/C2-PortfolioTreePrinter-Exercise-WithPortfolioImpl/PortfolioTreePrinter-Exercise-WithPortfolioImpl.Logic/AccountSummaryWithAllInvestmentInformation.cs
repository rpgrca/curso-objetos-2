using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class AccountSummaryWithAllInvestmentInformation
    {
        private readonly SummarizingAccount _account;

        public AccountSummaryWithAllInvestmentInformation(SummarizingAccount account) =>
            _account = account;

        public List<string> Lines()
        {
            var summary = new AccountSummaryWithInvestmentEarnings(_account);
            var investmentNet = new InvestmentNet(_account);
            var future = new Future<double>(() => investmentNet.Value());

            var lines = summary.Lines();
            lines.Add($"Inversiones por {future.Value()}");

            return lines;
        }
    }
}