using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Portfolio : SummarizingAccount
    {
        public const string ACCOUNT_NOT_MANAGED = "No se maneja esta cuenta";
        public const string ACCOUNT_ALREADY_MANAGED = "La cuenta ya está manejada por otro portfolio";
        private readonly IList<SummarizingAccount> _summarizingAccounts;

        public static Portfolio CreateWith(SummarizingAccount anAccout)
        {
            var summarizingAccounts = new List<SummarizingAccount>
            {
                anAccout
            };

            return CreateWith(summarizingAccounts);
        }

        public static Portfolio CreateWith(SummarizingAccount anAccount1, SummarizingAccount anAccount2)
        {
            var summarizingAccounts = new List<SummarizingAccount>
            {
                anAccount1,
                anAccount2
            };

            return CreateWith(summarizingAccounts);
        }

        public static Portfolio CreateWith(List<SummarizingAccount> summarizingAccounts)
        {
            if (new HashSet<SummarizingAccount>(summarizingAccounts).Count != summarizingAccounts.Count)
                throw new Exception(ACCOUNT_ALREADY_MANAGED);

            foreach (var summarizingAccountSource in summarizingAccounts)
            {
                foreach (var summarizingAccountTarget in summarizingAccounts)
                {
                    if (summarizingAccountSource != summarizingAccountTarget && summarizingAccountSource.Manages(summarizingAccountTarget))
                    {
                        throw new Exception(ACCOUNT_ALREADY_MANAGED);
                    }
                }
            }

            return new Portfolio(summarizingAccounts);
        }

        private Portfolio(List<SummarizingAccount> summarizingAccounts) =>
            _summarizingAccounts = summarizingAccounts;

        public double Balance() =>
            _summarizingAccounts.Sum(summarizingAccount => summarizingAccount.Balance());

        public bool Registers(AccountTransaction transaction) =>
            _summarizingAccounts.Any(summarizingAccount => summarizingAccount.Registers(transaction));

        public IList<AccountTransaction> TransactionsOf(SummarizingAccount account) =>
            Manages(account)
                ? account.Transactions()
                : throw new Exception(ACCOUNT_NOT_MANAGED);

        public bool Manages(SummarizingAccount account) =>
            this == account || _summarizingAccounts.Any(summarizingAccount => summarizingAccount.Manages(account));

        public IList<AccountTransaction> Transactions()
        {
            var transactions = new List<AccountTransaction>();

            foreach (var summarizingAccount in _summarizingAccounts)
            {
                transactions.AddRange(summarizingAccount.Transactions());
            }

            return transactions;
        }

        public void Accept(AccountTransactionVisitor aVisitor)
        {
            foreach (var transaction in Transactions())
            {
                transaction.Accept(aVisitor);
            }
        }

        public void Accept(SummarizingAccountVisitor aVisitor) =>
            aVisitor.VisitPortfolio(this);

        public void visitAccountsWith(SummarizingAccountVisitor aVisitor)
        {
            foreach (var summarizinAccount in _summarizingAccounts)
            {
                summarizinAccount.Accept(aVisitor);
            }
        }
    }
}