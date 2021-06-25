namespace C2_PortfolioTreePrinter_Exercise
{
    internal class TransferNet
    {
        private readonly ReceptiveAccount _account;

        public TransferNet(ReceptiveAccount account) => _account = account;

        public double Total()
        {
            var transferNet = 0.0;

            foreach (var transaction in _account.transactions())
            {
                transferNet = transaction.applyTransferTo(transferNet);
            }

            return transferNet;
        }
    }
}