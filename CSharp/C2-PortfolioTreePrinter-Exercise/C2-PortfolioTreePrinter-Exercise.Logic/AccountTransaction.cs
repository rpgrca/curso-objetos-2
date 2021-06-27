namespace C2_PortfolioTreePrinter_Exercise.Logic
{
    public interface AccountTransaction
    {
        double value();
        string Humanize();
        double applyTo(double balance);
        double applyTransferTo(double balance);
        double applyInvestmentTo(double balance);
        double applyInvestmentEarningsTo(double investmentEarnings);
    }
}
