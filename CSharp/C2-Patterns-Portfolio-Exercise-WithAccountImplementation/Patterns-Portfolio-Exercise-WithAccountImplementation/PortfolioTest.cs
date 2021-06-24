using System;
using Xunit;

namespace Patterns_Portfolio_Exercise_WithAccountImplementation
{
    public class PortfolioTest
    {
        [Fact]
        public void test01ReceptiveAccountHaveZeroAsBalanceWhenCreated()
        {
            var account = new ReceptiveAccount();

            Assert.Equal(0.0, account.balance());
        }

        [Fact]
        public void test02DepositIncreasesBalanceOnTransactionValue()
        {
            var account = new ReceptiveAccount();
            Deposit.registerForOn(100, account);

            Assert.Equal(100.0, account.balance());
        }

        [Fact]
        public void test03WithdrawDecreasesBalanceOnTransactionValue()
        {
            var account = new ReceptiveAccount();
            Deposit.registerForOn(100, account);
            Withdraw.registerForOn(-50, account);

            Assert.Equal(50.0, account.balance());
        }

        [Fact]
        public void test04PortfolioBalanceIsSumOfManagedAccountsBalance()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);

            Deposit.registerForOn(100, account1);
            Deposit.registerForOn(200, account2);

            Assert.Equal(300.0, complexPortfolio.balance());
        }

        [Fact]
        public void test05PortfolioCanManagePortfolios()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            Deposit.registerForOn(100, account1);
            Deposit.registerForOn(200, account2);
            Deposit.registerForOn(300, account3);
            Assert.Equal(600.0, composedPortfolio.balance());
        }

        [Fact]
        public void test06ReceptiveAccountsKnowsRegisteredTransactions()
        {
            var account = new ReceptiveAccount();
            var deposit = Deposit.registerForOn(100, account);
            var withdraw = Withdraw.registerForOn(-50, account);

            Assert.True(account.registers(deposit));
            Assert.True(account.registers(withdraw));
        }

        [Fact]
        public void test07ReceptiveAccountsDoNotKnowNotRegisteredTransactions()
        {
            var account = new ReceptiveAccount();
            var deposit = new Deposit(100);
            var withdraw = new Withdraw(-50);

            Assert.False(account.registers(deposit));
            Assert.False(account.registers(withdraw));
        }

        [Fact]
        public void test08PortofoliosKnowsTransactionsRegisteredByItsManagedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            var deposit1 = Deposit.registerForOn(100, account1);
            var deposit2 = Deposit.registerForOn(200, account2);
            var deposit3 = Deposit.registerForOn(300, account3);

            Assert.True(composedPortfolio.registers(deposit1));
            Assert.True(composedPortfolio.registers(deposit2));
            Assert.True(composedPortfolio.registers(deposit3));
        }

        [Fact]
        public void test09PortofoliosDoNotKnowTransactionsNotRegisteredByItsManagedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            var deposit1 = new Deposit(100);
            var deposit2 = new Deposit(200);
            var deposit3 = new Deposit(300);

            Assert.False(composedPortfolio.registers(deposit1));
            Assert.False(composedPortfolio.registers(deposit2));
            Assert.False(composedPortfolio.registers(deposit3));
        }

        [Fact]
        public void test10ReceptiveAccountManageItSelf()
        {
            var account1 = new ReceptiveAccount();

            Assert.True(account1.manages(account1));
        }

        [Fact]
        public void test11ReceptiveAccountDoNotManageOtherAccount()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();

            Assert.False(account1.manages(account2));
        }

        [Fact]
        public void test12PortfolioManagesComposedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);

            Assert.True(complexPortfolio.manages(account1));
            Assert.True(complexPortfolio.manages(account2));
            Assert.False(complexPortfolio.manages(account3));
        }

        [Fact]
        public void test13PortfolioManagesComposedAccountsAndPortfolios()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            Assert.True(composedPortfolio.manages(account1));
            Assert.True(composedPortfolio.manages(account2));
            Assert.True(composedPortfolio.manages(account3));
            Assert.True(composedPortfolio.manages(complexPortfolio));
        }

        [Fact]
        public void test14AccountsKnowsItsTransactions()
        {
            var account1 = new ReceptiveAccount();

            var deposit1 = Deposit.registerForOn(100, account1);

            Assert.Single(account1.transactions(), deposit1);
        }

        [Fact]
        public void test15PortfolioKnowsItsAccountsTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            var deposit1 = Deposit.registerForOn(100, account1);
            var deposit2 = Deposit.registerForOn(200, account2);
            var deposit3 = Deposit.registerForOn(300, account3);

            Assert.Equal(3, composedPortfolio.transactions().Count);
            Assert.Contains(deposit1, composedPortfolio.transactions());
            Assert.Contains(deposit2, composedPortfolio.transactions());
            Assert.Contains(deposit3, composedPortfolio.transactions());
        }

        [Fact]
        public void test16PortofolioKnowsItsAccountsTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            var deposit1 = Deposit.registerForOn(100, account1);

            Assert.Single(composedPortfolio.transactionsOf(account1), deposit1);
        }

        [Fact]
        public void test17PortofolioKnowsItsPortfoliosTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            var composedPortfolio = Portfolio.createWith(complexPortfolio, account3);

            var deposit1 = Deposit.registerForOn(100, account1);
            var deposit2 = Deposit.registerForOn(100, account2);
            Deposit.registerForOn(100, account3);

            Assert.Equal(2, composedPortfolio.transactionsOf(complexPortfolio).Count);
            Assert.Contains(deposit1, composedPortfolio.transactionsOf(complexPortfolio));
            Assert.Contains(deposit2, composedPortfolio.transactionsOf(complexPortfolio));
        }

        [Fact]
        public void test18PortofolioCanNotAnswerTransactionsOfNotManagedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);

            try
            {
                complexPortfolio.transactionsOf(account3);
                Assert.True(false);
            }
            catch (Exception accountNotManaged)
            {
                Assert.Equal(Portfolio.ACCOUNT_NOT_MANAGED, accountNotManaged.Message);
            }
        }

        [Fact]
        public void test19CanNotCreatePortfoliosWithRepeatedAccount()
        {
            var account1 = new ReceptiveAccount();
            try
            {
                Portfolio.createWith(account1, account1);
                Assert.True(false);
            }
            catch (Exception invalidPortfolio)
            {
                Assert.Equal(Portfolio.ACCOUNT_ALREADY_MANAGED, invalidPortfolio.Message);
            }
        }

        [Fact]
        public void test20CanNotCreatePortfoliosWithAccountsManagedByOtherManagedPortfolio()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.createWith(account1, account2);
            try
            {
                Portfolio.createWith(complexPortfolio, account1);
                Assert.True(false);
            }
            catch (Exception invalidPortfolio)
            {
                Assert.Equal(Portfolio.ACCOUNT_ALREADY_MANAGED, invalidPortfolio.Message);
            }
        }
    }
}
