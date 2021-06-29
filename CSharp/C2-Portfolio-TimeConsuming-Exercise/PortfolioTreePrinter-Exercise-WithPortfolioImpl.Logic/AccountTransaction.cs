namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface AccountTransaction
    {
        double value();
        void accept(AccountTransactionVisitor visitor);
    }
}