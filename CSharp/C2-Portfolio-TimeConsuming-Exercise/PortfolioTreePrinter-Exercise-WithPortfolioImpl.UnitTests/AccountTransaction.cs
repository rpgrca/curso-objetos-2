namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    interface AccountTransaction
    {
        double value();
        void accept(AccountTransactionVisitor visitor);
    }
}