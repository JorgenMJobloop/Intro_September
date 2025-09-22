public class CompanyAccount : Account
{
    public CompanyAccount(string accountnumber) : base(accountnumber)
    {

    }

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