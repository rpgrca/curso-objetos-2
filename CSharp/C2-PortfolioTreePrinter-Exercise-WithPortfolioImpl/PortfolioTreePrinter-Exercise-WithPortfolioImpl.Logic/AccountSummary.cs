using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class AccountSummary : AccountTransactionVisitor
    {
        private readonly SummarizingAccount _account;
        private List<string> _lines;

        public AccountSummary(SummarizingAccount account) =>
            _account = account;

        public List<string> Lines()
        {
            //System.Threading.Thread.Sleep(1000);

            _lines = new List<string>();

            _account.Accept(this);
            return _lines;
        }

        public void VisitDeposit(Deposit deposit) =>
            _lines.Add($"Depósito por {deposit.Value()}");

        public void VisitWithdraw(Withdraw withdraw) =>
            _lines.Add($"Extracción por {withdraw.Value()}");

        public void VisitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit) =>
            _lines.Add($"Plazo fijo por {certificateOfDeposit.Value()} durante {certificateOfDeposit.NumberOfDays()} días a una tna de {certificateOfDeposit.Tna()}");

        public void VisitTransferDeposit(TransferDeposit transferDeposit) =>
            _lines.Add($"Transferencia por {transferDeposit.Value()}");

        public void VisitTransferWithdraw(TransferWithdraw transferWithdraw) =>
            _lines.Add($"Transferencia por {-transferWithdraw.Value()}");
    }
}