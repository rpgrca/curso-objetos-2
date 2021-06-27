namespace PortfolioTreePrinter_Exercise.Logic
{
    public class TransferNet : Classificator
    {
        public TransferNet(ReceptiveAccount account) : base(account)
        {
        }

        public override double applyTo(DepositLeg depositLeg, double balance) =>
            depositLeg.applyTo(balance);

        public override double applyTo(WithdrawLeg withdrawLeg, double balance) =>
            withdrawLeg.applyTo(balance);
    }
}