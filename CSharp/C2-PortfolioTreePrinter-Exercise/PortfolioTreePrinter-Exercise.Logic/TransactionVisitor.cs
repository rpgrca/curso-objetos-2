using System;

namespace PortfolioTreePrinter_Exercise.Logic
{
    public abstract class TransactionVisitor
    {
        private readonly ReceptiveAccount _account;

        public TransactionVisitor(ReceptiveAccount account) => _account = account;

        public void Compute() => _account.visitTransactions(this);

        public virtual void visit(Withdraw withdraw)
        {
        }

        public virtual void visit(Deposit deposit)
        {
        }

        public virtual void visit(DepositLeg depositLeg)
        {
        }

        public virtual void visit(WithdrawLeg withdrawLeg)
        {
        }

        public virtual void visit(CertificateOfDeposit certificateOfDeposit)
        {
        }
    }
}