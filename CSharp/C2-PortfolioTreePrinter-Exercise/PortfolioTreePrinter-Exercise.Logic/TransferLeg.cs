namespace PortfolioTreePrinter_Exercise.Logic
{
    public interface TransferLeg: AccountTransaction
    {
        Transfer transfer();
    }
}
