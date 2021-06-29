namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface AccountTransaction
    {
        double Value();
        void Accept(AccountTransactionVisitor visitor);
    }
}