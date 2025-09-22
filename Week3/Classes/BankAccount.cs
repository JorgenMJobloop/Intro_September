public class BankAccount : Account
{
    public BankAccount(string accountnumber) : base(accountnumber)
    {
    }

    public string? Accountnumber { get; set; }
    //public double AvailableCredit { get; set; }

    public override void Deposit(double amount)
    {
        Credit += amount;
    }

    public override bool Widthdraw(double amount)
    {
        if (amount > Credit)
        {
            return false;
        }
        Credit -= amount;
        return true;
    }
}