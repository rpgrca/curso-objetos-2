using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class AccountSummaryWithInvestmentEarnings
    {
        private readonly SummarizingAccount _account;

        public AccountSummaryWithInvestmentEarnings(SummarizingAccount account) =>
            _account = account;

        public List<string> Lines()
        {
            var summary = new AccountSummary(_account);
            var investmentEarnings = new InvestmentEarnings(_account);

            var future = new Future<double>(() => investmentEarnings.Value());
            var lines = summary.Lines();

            lines.Add($"Ganancias por {future.Value()}");
            return lines;
        }
    }
}