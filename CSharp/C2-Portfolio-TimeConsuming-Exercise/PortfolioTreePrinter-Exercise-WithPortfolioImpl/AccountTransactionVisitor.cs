using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    interface AccountTransactionVisitor
    {
	    void visitDeposit(Deposit deposit);
	    void visitTransferDeposit(TransferDeposit transferDeposit);
	    void visitTransferWithdraw(TransferWithdraw transferWithdraw);
	    void visitWithdraw(Withdraw withdraw);
	    void visitCertificateOfDeposit(CertificateOfDeposit certificateOfDeposit);
	
    }
}
