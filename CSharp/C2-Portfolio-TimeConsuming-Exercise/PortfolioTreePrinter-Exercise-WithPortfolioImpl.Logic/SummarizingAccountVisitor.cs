namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface SummarizingAccountVisitor
    {
        void visitPortfolio(Portfolio portfolio);
        void visitReceptiveAccount(ReceptiveAccount receptiveAccount);
    }
}