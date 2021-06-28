using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public abstract class SummarizingAccount
    {
        public abstract double balance { get; }

        public abstract bool registers(AccountTransaction transaction);

        public abstract bool manages(SummarizingAccount account);

        public abstract IList<AccountTransaction> transactions();

        public void visitTransactions(TransactionVisitor visitor)
        {
            foreach (var transaction in transactions())
            {
                transaction.accept(visitor);
            }
        }

        public abstract void accept(TreePrinterVisitor visitor);
    }
}