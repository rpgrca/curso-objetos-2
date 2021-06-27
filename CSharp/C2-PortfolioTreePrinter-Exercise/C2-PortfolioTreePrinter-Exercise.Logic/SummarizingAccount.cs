using System.Collections.Generic;

namespace C2_PortfolioTreePrinter_Exercise.Logic
{
    public interface SummarizingAccount
    {
        double balance();
        bool registers(AccountTransaction transaction);
        bool manages(SummarizingAccount account);
        IList<AccountTransaction> transactions();
    }
}