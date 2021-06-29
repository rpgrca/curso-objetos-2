using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Portfolio: SummarizingAccount
    {
        public static String ACCOUNT_NOT_MANAGED = "No se maneja esta cuenta";
        public static String ACCOUNT_ALREADY_MANAGED = "La cuenta ya está manejada por otro portfolio";
        private IList<SummarizingAccount> summarizingAccounts; 

        public static Portfolio createWith(SummarizingAccount anAccout){
            List<SummarizingAccount> summarizingAccounts = new List<SummarizingAccount>();
            summarizingAccounts.Add(anAccout);

            return Portfolio.createWith(summarizingAccounts);
        }

        public static Portfolio createWith(SummarizingAccount anAccount1, SummarizingAccount anAccount2) {
            List<SummarizingAccount> summarizingAccounts = new List<SummarizingAccount>();
            summarizingAccounts.Add(anAccount1);
            summarizingAccounts.Add(anAccount2);

            return Portfolio.createWith(summarizingAccounts);
        }

        public static Portfolio createWith(List<SummarizingAccount> summarizingAccounts) {
            if(new HashSet<SummarizingAccount>(summarizingAccounts).Count!=summarizingAccounts.Count)
                throw new Exception(ACCOUNT_ALREADY_MANAGED);

            foreach (SummarizingAccount summarizingAccountSource in summarizingAccounts)
                foreach (SummarizingAccount summarizingAccountTarget in summarizingAccounts)
                    if (summarizingAccountSource!=summarizingAccountTarget)
                        if(summarizingAccountSource.manages(summarizingAccountTarget))
                            throw new Exception(ACCOUNT_ALREADY_MANAGED);

            return new Portfolio(summarizingAccounts);
        }
    
        private Portfolio(List<SummarizingAccount> summarizingAccounts){
            this.summarizingAccounts = summarizingAccounts;
        }

        public double balance() {
            return summarizingAccounts.Sum( summarizingAccount => summarizingAccount.balance() );
        }

        public bool registers(AccountTransaction transaction) {
            return summarizingAccounts.Any( summarizingAccount => summarizingAccount.registers(transaction) );
        }

        public IList<AccountTransaction> transactionsOf(SummarizingAccount account) {
            if (manages(account))
                return account.transactions();
            else
                throw new Exception (ACCOUNT_NOT_MANAGED);
        }

        public bool manages(SummarizingAccount account) {
            return this == account || summarizingAccounts.Any( summarizingAccount => summarizingAccount.manages(account) );
        }

        public IList<AccountTransaction> transactions() {
            List<AccountTransaction> transactions = new List<AccountTransaction>();
            foreach (SummarizingAccount summarizingAccount in summarizingAccounts)
                transactions.AddRange(summarizingAccount.transactions());

            return transactions;
        }

        public void acceptTransactionsVisitor(AccountTransactionVisitor aVisitor)
        {
            foreach (AccountTransaction transaction in transactions())
                transaction.accept(aVisitor);
        }

        public void accept(SummarizingAccountVisitor aVisitor)
        {
            aVisitor.visitPortfolio(this);
        }

        public void visitAccountsWith(SummarizingAccountVisitor aVisitor)
        {
            foreach (SummarizingAccount summarizinAccount in summarizingAccounts) {
                summarizinAccount.accept(aVisitor);
        }
    }
}
}