public class SavingsAccount : Account
{
    public double Interest { get; set; }

    public SavingsAccount(string accountnumber, double interest) : base(accountnumber)
    {
        Interest = interest;
    }

    public void AddInterest()
    {
        Deposit(Credit * Interest);
    }
}