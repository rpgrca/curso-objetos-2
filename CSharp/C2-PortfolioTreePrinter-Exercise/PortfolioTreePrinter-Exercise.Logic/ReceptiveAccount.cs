using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class ReceptiveAccount : SummarizingAccount
    {
        private readonly IList<AccountTransaction> m_transactions = new List<AccountTransaction>();

        public override double balance
        {
            get
            {
                var balance = 0.0;

                foreach (var transaction in m_transactions)
                {
                    balance = transaction.applyTo(balance);
                }

                return balance;
            }
        }

        public void register(AccountTransaction transaction) =>
            m_transactions.Add(transaction);

        public override bool registers(AccountTransaction transaction) =>
            m_transactions.Contains(transaction);

        public override bool manages(SummarizingAccount account) =>
            this == account;

        public override IList<AccountTransaction> transactions() =>
            new List<AccountTransaction>(m_transactions);
   }
}
