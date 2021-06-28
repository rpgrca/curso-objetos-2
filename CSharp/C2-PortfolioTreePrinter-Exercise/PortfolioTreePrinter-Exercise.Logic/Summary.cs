using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class Summary : TransactionVisitor
    {
        private readonly List<string> _summary;

        public Summary(ReceptiveAccount fromAccount) : base(fromAccount)
        {
            _summary = new();
            Compute();
        }

        public override void visit(Withdraw withdraw) =>
            _summary.Add($"Extracción por {withdraw.value():F1}");

        public override void visit(Deposit deposit) =>
            _summary.Add($"Depósito por {deposit.value():F1}");

        public override void visit(DepositLeg depositLeg) =>
            _summary.Add($"Transferencia por {depositLeg.value():F1}");

        public override void visit(WithdrawLeg withdrawLeg) =>
            _summary.Add($"Transferencia por -{withdrawLeg.value():F1}");

        public override void visit(CertificateOfDeposit certificateOfDeposit) =>
            _summary.Add($"Plazo fijo por {certificateOfDeposit.value():F1} durante {certificateOfDeposit.numberOfDays()} días a una tna de {certificateOfDeposit.tna():F1}");

        public List<string> Value() => _summary;
    }
}