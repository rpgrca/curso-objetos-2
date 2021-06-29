namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface TransferLeg : AccountTransaction
    {
        Transfer Transfer();
    }
}