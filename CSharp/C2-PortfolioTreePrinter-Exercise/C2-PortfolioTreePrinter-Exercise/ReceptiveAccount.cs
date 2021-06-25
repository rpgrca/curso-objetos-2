using System.Collections.Generic;
using System.Linq;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal class ReceptiveAccount : SummarizingAccount
    {
        private readonly IList<AccountTransaction> m_transactions = new List<AccountTransaction>();

        public double balance() =>
            m_transactions.Sum(transaction => transaction.value());

        public void register(AccountTransaction transaction) =>
            m_transactions.Add(transaction);

        public bool registers(AccountTransaction transaction) =>
            m_transactions.Contains(transaction);

        public bool manages(SummarizingAccount account) =>
            this == account;

        public IList<AccountTransaction> transactions() =>
            new List<AccountTransaction>(m_transactions);
    }
}
