public abstract class Account
{
    public string? AccountNumber { get; set; }
    public double Credit { get; protected set; }

    public Account(string accountnumber)
    {
        AccountNumber = accountnumber;
    }

    public virtual void Deposit(double amount)
    {
        Credit += amount;
    }
    public virtual bool Widthdraw(double amount)
    {
        if (amount > Credit)
        {
            return false;
        }
        Credit -= amount;
        return true;
    }

}