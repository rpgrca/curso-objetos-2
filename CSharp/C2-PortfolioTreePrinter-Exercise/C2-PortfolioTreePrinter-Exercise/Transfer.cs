using System;

namespace C2_PortfolioTreePrinter_Exercise
{
    internal class Transfer
    {
        public Transfer(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount) =>
            throw new Exception();

        public static Transfer registerFor(double value, ReceptiveAccount fromAccount, ReceptiveAccount toAccount) =>
            throw new Exception();

        public double value() => throw new Exception();

        public TransferLeg depositLeg() => throw new Exception();

        public TransferLeg withdrawLeg() => throw new Exception();
    }
}
