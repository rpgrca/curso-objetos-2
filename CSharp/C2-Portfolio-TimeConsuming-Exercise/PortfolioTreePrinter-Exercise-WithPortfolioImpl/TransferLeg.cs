using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    interface TransferLeg : AccountTransaction
    {
        Transfer transfer();
    }
}
