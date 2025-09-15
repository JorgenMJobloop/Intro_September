public class Customer
{
    public string? Name { get; private set; }
    public List<BankAccount>? Accounts { get; private set; }

    public Customer(string name)
    {
        Name = name;
        Accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account)
    {
        Accounts!.Add(account);
    }

    public void DisplayAccounts()
    {
        foreach (var account in Accounts!)
        {
            Console.WriteLine(account);   
        }
    }
}