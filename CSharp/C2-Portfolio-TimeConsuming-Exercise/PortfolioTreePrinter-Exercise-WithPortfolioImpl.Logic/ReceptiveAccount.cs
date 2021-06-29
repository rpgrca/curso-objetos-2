using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class ReceptiveAccount : SummarizingAccount
    {
        private readonly IList<AccountTransaction> _transactions = new List<AccountTransaction>();

        public double Balance() =>
            new BalanceVisitor(this).Value();

        public void Register(AccountTransaction transaction) =>
            _transactions.Add(transaction);

        public bool Registers(AccountTransaction transaction) =>
            _transactions.Contains(transaction);

        public bool Manages(SummarizingAccount account) =>
            this == account;

        public IList<AccountTransaction> Transactions() =>
            new List<AccountTransaction>(_transactions);

        public void Accept(AccountTransactionVisitor aVisitor)
        {
            foreach (var transaction in _transactions)
            {
                transaction.Accept(aVisitor);
            }
        }

        public void Accept(SummarizingAccountVisitor aVisitor) =>
            aVisitor.VisitReceptiveAccount(this);
    }
}