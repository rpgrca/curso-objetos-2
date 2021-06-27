namespace C2_PortfolioTreePrinter_Exercise.Logic
{
    public interface TransferLeg: AccountTransaction
    {
        Transfer transfer();
    }
}
