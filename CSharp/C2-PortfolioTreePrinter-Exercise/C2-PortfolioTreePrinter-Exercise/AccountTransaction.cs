namespace C2_PortfolioTreePrinter_Exercise
{
    internal interface AccountTransaction
    {
        double value();
        double applyTo(double balance);
        string Humanize();
        double applyTransferTo(double balance);
    }
}
