using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class AccountSummaryWithInvestmentEarnings
    {
        private SummarizingAccount account;

        public AccountSummaryWithInvestmentEarnings(SummarizingAccount account) {
            this.account = account;
        }

        public List<string> lines() {
            AccountSummary summary = new AccountSummary(account);
            InvestmentEarnings investmentEarnings = new InvestmentEarnings(account);

            var future = new Future<double>(() => investmentEarnings.value());
            List<string> lines = summary.lines();

            lines.Add($"Ganancias por {future.Value()}");
            return lines;
        }
    }
}