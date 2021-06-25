using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface AccountTransaction
    {
        double value();
        double applyTo(double balance);
    }
}
