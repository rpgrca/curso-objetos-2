using System;
using System.Collections.Generic;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public class InvestmentNet : TransactionVisitor
    {
        private double _balance;

        public InvestmentNet(ReceptiveAccount account) : base(account) =>
            Compute();

        public override void visit(CertificateOfDeposit certificateOfDeposit) =>
            _balance += certificateOfDeposit.value();

        public double Value() => _balance;
    }
}