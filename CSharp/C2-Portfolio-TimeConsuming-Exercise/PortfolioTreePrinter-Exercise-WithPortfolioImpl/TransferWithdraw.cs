using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    class TransferWithdraw : TransferLeg
    {
        private Transfer m_transfer;

        public TransferWithdraw(Transfer transfer)
        {
            m_transfer = transfer;
        }

        public double value()
        {
            return m_transfer.value();
        }

        public void accept(AccountTransactionVisitor visitor)
        {
            visitor.visitTransferWithdraw(this);
        }

        public Transfer transfer()
        {
            return m_transfer;
        }

    }
}
