using System.Collections.Generic;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface SummarizingAccount
    {
        double balance();
        bool registers(AccountTransaction transaction);
        bool manages(SummarizingAccount account);
        IList<AccountTransaction> transactions();
    }
}