using System.Collections.Generic;

namespace Patterns_Portfolio_Exercise_WithAccountImplementation
{
    internal interface SummarizingAccount
    {
        double balance();
        bool registers(AccountTransaction transaction);
        bool manages(SummarizingAccount account);
        List<AccountTransaction> transactions();
    }
}