namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public class Transfer
    {
        private double m_value;
        private ReceptiveAccount m_fromAccount;
        private ReceptiveAccount m_toAccount;
        private TransferDeposit m_depositLeg;
        private TransferWithdraw m_withdrawLeg;

        public Transfer(double value, ReceptiveAccount fromAccount,
                ReceptiveAccount toAccount)
        {
            m_value = value;
            m_fromAccount = fromAccount;
            m_toAccount = toAccount;
            m_depositLeg = new TransferDeposit(this);
            m_withdrawLeg = new TransferWithdraw(this);
        }

        public static Transfer registerFor(double value, ReceptiveAccount fromAccount,
                ReceptiveAccount toAccount)
        {
            Transfer transfer = new Transfer(value, fromAccount, toAccount);
            fromAccount.register(transfer.withdrawLeg());
            toAccount.register(transfer.depositLeg());

            return transfer;
        }

        public double value()
        {
            return m_value;
        }

        public TransferLeg withdrawLeg()
        {
            return m_withdrawLeg;
        }

        public TransferLeg depositLeg()
        {
            return m_depositLeg;
        }
    }
}