using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface SummarizingAccount
    {
        double Balance();
        bool Registers(AccountTransaction transaction);
        bool Manages(SummarizingAccount account);
        IList<AccountTransaction> Transactions();
        void Accept(AccountTransactionVisitor aVisitor);
        void Accept(SummarizingAccountVisitor aVisitor);
    }
}