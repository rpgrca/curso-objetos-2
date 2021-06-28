using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class AccountSummary: AccountTransactionVisitor
    {
        private SummarizingAccount account;
        private List<String> m_lines;

        public AccountSummary(SummarizingAccount account)
        {
            this.account = account;
        }

        public List<String> lines() {
            System.Threading.Thread.Sleep(1000);

            m_lines = new List<String>();

            account.acceptTransactionsVisitor(this);
            return m_lines;
        }

        public void visitDeposit(Deposit deposit) {
            m_lines.Add("Depósito por " + deposit.value() );
        }

        public void visitWithdraw(Withdraw withdraw) {
            m_lines.Add("Extracción por " + withdraw.value() );
        }

        public void visitCertificateOfDeposit(
                CertificateOfDeposit certificateOfDeposit) {
            m_lines.Add(
                    "Plazo fijo por " + certificateOfDeposit.value()+ 
                    " durante " + certificateOfDeposit.numberOfDays()+
                    " días a una tna de " + certificateOfDeposit.tna());
        }

        public void visitTransferDeposit(TransferDeposit transferDeposit) {
            m_lines.Add("Transferencia por " + transferDeposit.value () );
        }

        public void visitTransferWithdraw(TransferWithdraw transferWithdraw) {
            m_lines.Add("Transferencia por " + -transferWithdraw.value () );
        }
    }
}