using System.Collections.Generic;
using System.Linq;

namespace Patterns_Portfolio_Exercise_WithAccountImplementation.Logic
{
    public class ReceptiveAccount: SummarizingAccount
    {
        private readonly List<AccountTransaction> _transactions = new();

        public double balance() =>
            _transactions.Sum(transaction => transaction.value());

        public void register(AccountTransaction transaction) =>
            _transactions.Add(transaction);

        public bool registers(AccountTransaction transaction) =>
            _transactions.Contains(transaction);

        public bool manages(SummarizingAccount account) =>
            this == account;

        public List<AccountTransaction> transactions() =>
            new(_transactions);
    }
}