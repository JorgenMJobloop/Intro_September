public class Customer
{
    public string? Name { get; set; }
    public List<Account> Accounts { get; } = new List<Account>();

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }

    public void DisplayFunds()
    {
        Console.WriteLine($"Available credit for {Name}:");
        Accounts.ForEach(acc => Console.WriteLine($"Account:{acc.AccountNumber}: {acc.Credit:C}"));
    }
}