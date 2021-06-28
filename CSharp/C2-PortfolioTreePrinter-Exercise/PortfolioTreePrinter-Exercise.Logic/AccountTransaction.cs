namespace PortfolioTreePrinter_Exercise.Logic
{
    public interface AccountTransaction
    {
        double value();
        void accept(TransactionVisitor visitor);
        double applyTo(double balance);
    }
}