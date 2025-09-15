public abstract class BankAccount
{
    public string? AccountNumber { get; protected set; }
    public string? Owner { get; protected set; }
    public double Balance { get; protected set; }

    public BankAccount(string accountNumber, string owner, double initalBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = initalBalance;
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);

    public override string ToString()
    {
        return $"{AccountNumber}::{Owner} : {Balance:C}";
    }
}