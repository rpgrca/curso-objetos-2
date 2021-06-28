namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl
{
    interface SummarizingAccountVisitor
    {
        void visitPortfolio(Portfolio portfolio);
        void visitReceptiveAccount(ReceptiveAccount receptiveAccount);
    }
}