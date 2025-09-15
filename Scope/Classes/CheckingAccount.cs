public class CheckingAccount : BankAccount
{
    /// <summary>
    /// The draft limit of the checking account.
    /// </summary>
    private double draftLimit = 500;
    public CheckingAccount(string accountNumber, string owner, double initalBalance) : base(accountNumber, owner, initalBalance)
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
        if (amount > 0 && Balance - amount >= -draftLimit)
        {
            Balance -= amount;
        }
    }
}