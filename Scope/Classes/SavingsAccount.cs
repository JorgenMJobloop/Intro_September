public class SavingsAccount : BankAccount
{
    /// <summary>
    /// 5% interest rate.
    /// </summary>
    private double interestRate = 0.05;

    public SavingsAccount(string accountNumber, string owner, double initalBalance) : base(accountNumber, owner, initalBalance)
    {

    }

    public override void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public override void Withdraw(double amount)
    {
        Balance += Balance * interestRate;
    }
}