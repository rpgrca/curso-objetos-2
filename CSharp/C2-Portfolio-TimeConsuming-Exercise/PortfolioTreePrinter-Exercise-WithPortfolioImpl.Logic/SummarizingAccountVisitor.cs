namespace PortfolioTreePrinter_Exercise_WithPortfolioImpl.Logic
{
    public interface SummarizingAccountVisitor
    {
        void VisitPortfolio(Portfolio portfolio);
        void VisitReceptiveAccount(ReceptiveAccount receptiveAccount);
    }
}