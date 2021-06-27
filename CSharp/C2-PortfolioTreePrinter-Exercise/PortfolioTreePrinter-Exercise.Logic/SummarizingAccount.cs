using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public interface SummarizingAccount
    {
        double balance { get; }

        bool registers(AccountTransaction transaction);
        bool manages(SummarizingAccount account);
        IList<AccountTransaction> transactions();
    }
}