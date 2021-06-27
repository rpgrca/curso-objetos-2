namespace PortfolioTreePrinter_Exercise.Logic
{
    public interface AccountTransaction
    {
        double value();
        string Humanize();
        double applyTo(double balance);
        double applyTo(Classificator classificator, double balance);
    }
}