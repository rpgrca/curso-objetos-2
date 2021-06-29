using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface SummarizingAccount
    {
        double balance(); 
        bool registers(AccountTransaction transaction);
        bool manages(SummarizingAccount account);
        IList<AccountTransaction> transactions();
        void acceptTransactionsVisitor(AccountTransactionVisitor aVisitor);
        void accept(SummarizingAccountVisitor aVisitor);
    }
}