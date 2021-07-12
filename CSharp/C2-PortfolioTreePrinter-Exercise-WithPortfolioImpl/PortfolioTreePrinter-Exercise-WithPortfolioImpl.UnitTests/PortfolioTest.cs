using System;
using System.Collections.Generic;
using Xunit;
using PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.UnitTests
{
    public class PortfolioTest
    {
        [Fact]
        public void test01ReceptiveAccountHaveZeroAsBalanceWhenCreated()
        {
            var account = new ReceptiveAccount();

            Assert.Equal(0.0, account.Balance());
        }

        [Fact]
        public void test02DepositIncreasesBalanceOnTransactionValue()
        {
            var account = new ReceptiveAccount();
            Deposit.RegisterForOn(100, account);

            Assert.Equal(100.0, account.Balance());
        }

        [Fact]
        public void test03WithdrawDecreasesBalanceOnTransactionValue()
        {
            var account = new ReceptiveAccount();
            Deposit.RegisterForOn(100, account);
            var withdraw = Withdraw.RegisterForOn(50, account);

            Assert.Equal(50.0, account.Balance());
            Assert.Equal(50.0, withdraw.Value());
        }

        [Fact]
        public void test04PortfolioBalanceIsSumOfManagedAccountsBalance()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);

            Deposit.RegisterForOn(100, account1);
            Deposit.RegisterForOn(200, account2);

            Assert.Equal(300.0, complexPortfolio.Balance());
        }

        [Fact]
        public void test05PortfolioCanManagePortfolios()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            Deposit.RegisterForOn(100, account1);
            Deposit.RegisterForOn(200, account2);
            Deposit.RegisterForOn(300, account3);
            Assert.Equal(600.0, composedPortfolio.Balance());
        }

        [Fact]
        public void test06ReceptiveAccountsKnowsRegisteredTransactions()
        {
            var account = new ReceptiveAccount();
            var deposit = Deposit.RegisterForOn(100, account);
            var withdraw = Withdraw.RegisterForOn(50, account);

            Assert.True(account.Registers(deposit));
            Assert.True(account.Registers(withdraw));
        }

        [Fact]
        public void test07PortofoliosKnowsTransactionsRegisteredByItsManagedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var deposit1 = Deposit.RegisterForOn(100, account1);
            var deposit2 = Deposit.RegisterForOn(200, account2);
            var deposit3 = Deposit.RegisterForOn(300, account3);

            Assert.True(composedPortfolio.Registers(deposit1));
            Assert.True(composedPortfolio.Registers(deposit2));
            Assert.True(composedPortfolio.Registers(deposit3));
        }

        [Fact]
        public void test08ReceptiveAccountManageItSelf()
        {
            var account1 = new ReceptiveAccount();

            Assert.True(account1.Manages(account1));
        }

        [Fact]
        public void test09ReceptiveAccountDoNotManageOtherAccount()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();

            Assert.False(account1.Manages(account2));
        }

        [Fact]
        public void test10PortfolioManagesComposedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);

            Assert.True(complexPortfolio.Manages(account1));
            Assert.True(complexPortfolio.Manages(account2));
            Assert.False(complexPortfolio.Manages(account3));
        }

        [Fact]
        public void test11PortfolioManagesComposedAccountsAndPortfolios()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            Assert.True(composedPortfolio.Manages(account1));
            Assert.True(composedPortfolio.Manages(account2));
            Assert.True(composedPortfolio.Manages(account3));
            Assert.True(composedPortfolio.Manages(complexPortfolio));
        }

        [Fact]
        public void test12AccountsKnowsItsTransactions()
        {
            var account1 = new ReceptiveAccount();

            var deposit1 = Deposit.RegisterForOn(100, account1);

            Assert.Equal(1, account1.Transactions().Count);
            Assert.True(account1.Transactions().Contains(deposit1));
        }

        [Fact]
        public void test13PortfolioKnowsItsAccountsTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var deposit1 = Deposit.RegisterForOn(100, account1);
            var deposit2 = Deposit.RegisterForOn(200, account2);
            var deposit3 = Deposit.RegisterForOn(300, account3);

            Assert.Equal(3, composedPortfolio.Transactions().Count);
            Assert.True(composedPortfolio.Transactions().Contains(deposit1));
            Assert.True(composedPortfolio.Transactions().Contains(deposit2));
            Assert.True(composedPortfolio.Transactions().Contains(deposit3));
        }

        [Fact]
        public void test14PortofolioKnowsItsAccountsTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var deposit1 = Deposit.RegisterForOn(100, account1);

            Assert.Equal(1, composedPortfolio.TransactionsOf(account1).Count);
            Assert.True(composedPortfolio.TransactionsOf(account1).Contains(deposit1));
        }

        [Fact]
        public void test15PortofolioKnowsItsPortfoliosTransactions()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var deposit1 = Deposit.RegisterForOn(100, account1);
            var deposit2 = Deposit.RegisterForOn(100, account2);
            Deposit.RegisterForOn(100, account3);

            Assert.Equal(2, composedPortfolio.TransactionsOf(complexPortfolio).Count);
            Assert.True(composedPortfolio.TransactionsOf(complexPortfolio).Contains(deposit1));
            Assert.True(composedPortfolio.TransactionsOf(complexPortfolio).Contains(deposit2));
        }

        [Fact]
        public void test16PortofolioCanNotAnswerTransactionsOfNotManagedAccounts()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);

            try
            {
                complexPortfolio.TransactionsOf(account3);
                Assert.True(false);
            }
            catch (Exception accountNotManaged)
            {
                Assert.Equal(Portfolio.ACCOUNT_NOT_MANAGED, accountNotManaged.Message);
            }
        }

        [Fact]
        public void test17CanNotCreatePortfoliosWithRepeatedAccount()
        {
            var account1 = new ReceptiveAccount();

            try
            {
                Portfolio.CreateWith(account1, account1);
                Assert.True(false);
            }
            catch (Exception invalidPortfolio)
            {
                Assert.Equal(Portfolio.ACCOUNT_ALREADY_MANAGED, invalidPortfolio.Message);
            }
        }

        [Fact]
        public void test18CanNotCreatePortfoliosWithAccountsManagedByOtherManagedPortfolio()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);

            try
            {
                Portfolio.CreateWith(complexPortfolio, account1);
                Assert.True(false);
            }
            catch (Exception invalidPortfolio)
            {
                Assert.Equal(Portfolio.ACCOUNT_ALREADY_MANAGED, invalidPortfolio.Message);
            }
        }

        [Fact]
        public void test19aTransferShouldRegistersATransferDepositOnToAccount()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            var transfer = Transfer.RegisterFor(100, fromAccount, toAccount);

            Assert.True(toAccount.Registers(transfer.DepositLeg()));
        }

        [Fact]
        public void test19bTransferShouldRegistersATransferWithdrawOnFromAccount()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            var transfer = Transfer.RegisterFor(100, fromAccount, toAccount);

            Assert.True(fromAccount.Registers(transfer.WithdrawLeg()));
        }

        [Fact]
        public void test19cTransferLegsKnowTransfer()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            var transfer = Transfer.RegisterFor(100, fromAccount, toAccount);

            Assert.Equal(transfer.DepositLeg().Transfer(), transfer.WithdrawLeg().Transfer());
        }

        [Fact]
        public void test19dTransferKnowsItsValue()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            var transfer = Transfer.RegisterFor(100, fromAccount, toAccount);

            Assert.Equal(100, transfer.Value());
        }

        [Fact]
        public void test19eTransferShouldWithdrawFromFromAccountAndDepositIntoToAccount()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Transfer.RegisterFor(100, fromAccount, toAccount);

            Assert.Equal(-100.0, fromAccount.Balance());
            Assert.Equal(100.0, toAccount.Balance());
        }

        [Fact]
        public void test20AccountSummaryShouldProvideHumanReadableTransactionsDetail()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            Transfer.RegisterFor(50, toAccount, fromAccount);

            var lines = accountSummaryLines(fromAccount);

            Assert.Collection(lines,
                p1 => Assert.Equal("Depósito por 100", p1),
                p2 => Assert.Equal("Extracción por 50", p2),
                p3 => Assert.Equal("Transferencia por -100", p3),
                p4 => Assert.Equal("Transferencia por 50", p4));
        }

        private List<string> accountSummaryLines(ReceptiveAccount fromAccount) =>
            new AccountSummary(fromAccount).Lines();

        [Fact]
        public void test21ShouldBeAbleToBeQueryTransferNet()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            Transfer.RegisterFor(250, toAccount, fromAccount);

            Assert.Equal(150.0, accountTransferNet(fromAccount));
            Assert.Equal(-150.0, accountTransferNet(toAccount));
        }

        private double accountTransferNet(ReceptiveAccount account) =>
            new TransferNet(account).Value();

        [Fact]
        public void test22CertificateOfDepositShouldWithdrawInvestmentValue()
        {
            var account = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(1000, account);
            Withdraw.RegisterForOn(50, account);
            Transfer.RegisterFor(100, account, toAccount);
            CertificateOfDeposit.RegisterFor(100, 30, 0.1, account);

            Assert.Equal(100.0, investmentNet(account));
            Assert.Equal(750.0, account.Balance());
        }

        private double investmentNet(ReceptiveAccount account) =>
            new InvestmentNet(account).Value();

        [Fact]
        public void test23ShouldBeAbleToQueryInvestmentEarnings()
        {
            var account = new ReceptiveAccount();

            CertificateOfDeposit.RegisterFor(100, 30, 0.1, account);
            CertificateOfDeposit.RegisterFor(100, 60, 0.15, account);

            const double fixedInvestmentEarnings = (100.0 * (0.1 / 360) * 30) + (100.0 * (0.15 / 360) * 60);

            Assert.Equal(fixedInvestmentEarnings, investmentEarnings(account));
        }

        private double investmentEarnings(ReceptiveAccount account) =>
            new InvestmentEarnings(account).Value();

        [Fact]
        public void test24AccountSummaryShouldWorkWithCertificateOfDeposit()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            CertificateOfDeposit.RegisterFor(1000, 30, 0.1, fromAccount);

            var lines = accountSummaryLines(fromAccount);

            Assert.Collection(lines,
                p1 => Assert.Equal("Depósito por 100", p1),
                p2 => Assert.Equal("Extracción por 50", p2),
                p3 => Assert.Equal("Transferencia por -100", p3),
                p4 => Assert.Equal("Plazo fijo por 1000 durante 30 días a una tna de 0.1", p4));
        }

        [Fact]
        public void test25ShouldBeAbleToBeQueryTransferNetWithCertificateOfDeposit()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            Transfer.RegisterFor(250, toAccount, fromAccount);
            CertificateOfDeposit.RegisterFor(1000, 30, 0.1, fromAccount);

            Assert.Equal(150.0, accountTransferNet(fromAccount));
            Assert.Equal(-150.0, accountTransferNet(toAccount));
        }

        [Fact]
        public void test26PortfolioTreePrinter()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var accountNames = new Dictionary<SummarizingAccount, string>
            {
                { composedPortfolio, "composedPortfolio" },
                { complexPortfolio, "complexPortfolio" },
                { account1, "account1" },
                { account2, "account2" },
                { account3, "account3" }
            };

            var lines = portofolioTreeOf(composedPortfolio, accountNames);

            Assert.Collection(lines,
                p1 => Assert.Equal("composedPortfolio", p1),
                p2 => Assert.Equal(" complexPortfolio", p2),
                p3 => Assert.Equal("  account1", p3),
                p4 => Assert.Equal("  account2", p4),
                p5 => Assert.Equal(" account3", p5));
        }

        private List<string> portofolioTreeOf(Portfolio composedPortfolio,
                Dictionary<SummarizingAccount, string> accountNames) =>
                    new PortfolioTreePrinter(composedPortfolio, accountNames).Lines();

        [Fact]
        public void test27ReversePortfolioTreePrinter()
        {
            var account1 = new ReceptiveAccount();
            var account2 = new ReceptiveAccount();
            var account3 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1, account2);
            var composedPortfolio = Portfolio.CreateWith(complexPortfolio, account3);

            var accountNames = new Dictionary<SummarizingAccount, string>
            {
                { composedPortfolio, "composedPortfolio" },
                { complexPortfolio, "complexPortfolio" },
                { account1, "account1" },
                { account2, "account2" },
                { account3, "account3" }
            };

            var lines = reversePortofolioTreeOf(composedPortfolio, accountNames);

            Assert.Collection(lines,
                p1 => Assert.Equal(" account3", p1),
                p2 => Assert.Equal("  account2", p2),
                p3 => Assert.Equal("  account1", p3),
                p4 => Assert.Equal(" complexPortfolio", p4),
                p5 => Assert.Equal("composedPortfolio", p5));
        }

        private List<string> reversePortofolioTreeOf(Portfolio composedPortfolio,
                Dictionary<SummarizingAccount, string> accountNames) =>
                    new ReversePortfolioTreePrinter(composedPortfolio, accountNames).Lines();

        private void shouldTakeLessThan(Action should, double milliseconds)
        {
            var timeBeforeRunning = DateTime.Now;
            should();
            var timeAfterRunning = DateTime.Now;

            Assert.True(timeAfterRunning.Subtract(timeBeforeRunning).TotalMilliseconds < milliseconds);
        }

        [Fact]
        public void test28AccountSummaryWithInvestmentEarningsShouldNotTakeTooLong()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            CertificateOfDeposit.RegisterFor(1000, 360, 0.1, fromAccount);

            List<string> lines = null;
            shouldTakeLessThan(
                () => lines = new AccountSummaryWithInvestmentEarnings(fromAccount).Lines(),
                1500);

            Assert.Collection(lines,
                p1 => Assert.Equal("Depósito por 100", p1),
                p2 => Assert.Equal("Extracción por 50", p2),
                p3 => Assert.Equal("Transferencia por -100", p3),
                p4 => Assert.Equal("Plazo fijo por 1000 durante 360 días a una tna de 0.1", p4),
                p5 => Assert.Equal("Ganancias por 100", p5));
        }

        [Fact]
        public void test29AccountSummaryWithInvestmentFullInfoShouldNotTakeTooLong()
        {
            var fromAccount = new ReceptiveAccount();
            var toAccount = new ReceptiveAccount();

            Deposit.RegisterForOn(100, fromAccount);
            Withdraw.RegisterForOn(50, fromAccount);
            Transfer.RegisterFor(100, fromAccount, toAccount);
            CertificateOfDeposit.RegisterFor(1000, 360, 0.1, fromAccount);

            List<string> lines = null;
            shouldTakeLessThan(
                () => lines = new AccountSummaryWithAllInvestmentInformation(fromAccount).Lines(),
                1500);

            Assert.Collection(lines,
                p1 => Assert.Equal("Depósito por 100", p1),
                p2 => Assert.Equal("Extracción por 50", p2),
                p3 => Assert.Equal("Transferencia por -100", p3),
                p4 => Assert.Equal("Plazo fijo por 1000 durante 360 días a una tna de 0.1", p4),
                p5 => Assert.Equal("Ganancias por 100", p5),
                p6 => Assert.Equal("Inversiones por 1000", p6));
        }

        [Fact]
        public void test30PortfolioBalanceIsValueOfManagedAccountBalanceWhenCreatedWithOneAccount()
        {
            var account1 = new ReceptiveAccount();
            var complexPortfolio = Portfolio.CreateWith(account1);

            Deposit.RegisterForOn(100, account1);

            Assert.Equal(100.0, complexPortfolio.Balance());
        }
    }
}