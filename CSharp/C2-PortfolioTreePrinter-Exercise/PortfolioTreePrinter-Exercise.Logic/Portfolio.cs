using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class Portfolio : SummarizingAccount
    {
        public static string ACCOUNT_NOT_MANAGED = "No se maneja esta cuenta";
        public static string ACCOUNT_ALREADY_MANAGED = "La cuenta ya está manejada por otro portfolio";

        private readonly IList<SummarizingAccount> summarizingAccounts;

        public static Portfolio createWith(SummarizingAccount anAccount1, SummarizingAccount anAccount2)
        {
            var portfolio = new Portfolio();
            portfolio.add(anAccount1);
            portfolio.add(anAccount2);

            return portfolio;
        }

        public void add(SummarizingAccount account)
        {
            if (manages(account))
            {
                throw new Exception(ACCOUNT_ALREADY_MANAGED);
            }

            summarizingAccounts.Add(account);
        }

        public Portfolio() =>
            summarizingAccounts = new List<SummarizingAccount>();

        public override double balance =>
            summarizingAccounts.Sum(summarizingAccount => summarizingAccount.balance);

        public override bool registers(AccountTransaction transaction) =>
            summarizingAccounts.Any(summarizingAccount => summarizingAccount.registers(transaction));

        public override bool manages(SummarizingAccount account) =>
            this == account || summarizingAccounts.Any(summarizingAccount => summarizingAccount.manages(account));

        public override IList<AccountTransaction> transactions()
        {
            var transactions = new List<AccountTransaction>();

            foreach (SummarizingAccount summarizingAccount in summarizingAccounts)
                transactions.AddRange(summarizingAccount.transactions());

            return transactions;
        }
    }
}
