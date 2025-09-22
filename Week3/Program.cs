namespace Day1;

class Program
{
    static void Main(string[] args)
    {
        var customerOne = new Customer { Name = "John Doe" };
        var accountOne = new BankAccount("1001");
        accountOne.Deposit(5000);
        customerOne.AddAccount(accountOne);

        var customerTwo = new Customer { Name = "Jane Doe" };
        var accountTwo = new BankAccount("2002");
        accountTwo.Deposit(3000);
        customerTwo.AddAccount(accountTwo);

        customerOne.DisplayFunds();
        customerTwo.DisplayFunds();

        Transaction transaction = new Transaction();
        transaction.ExecuteTransaction(accountOne, accountTwo, 4000);

        customerOne.DisplayFunds();
        customerTwo.DisplayFunds();
    }
}
