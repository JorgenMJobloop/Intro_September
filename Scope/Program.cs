namespace Scope;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("John Doe", 40, ["Programming", "Gaming", "Skiing", "Biking", "Watching movies"]);
        string name = person.GetPersonName();
        Console.WriteLine(name);
        person.GetHobbies();

        Bank bank = new Bank();
        var customerOne = new Customer("John Doe");
        var accountOne = new SavingsAccount("1001", "John Doe", 1000);
        var accountTwo = new CheckingAccount("1002", "John Doe", 500);
        customerOne.AddAccount(accountOne);
        customerOne.AddAccount(accountTwo);
        accountOne.Deposit(500);

        var customerTwo = new Customer("Jane Doe");
        var accountThree = new CheckingAccount("1003", "Jane Doe", 2500);
        customerTwo.AddAccount(accountThree);

        bank.AddCustomer(customerOne);
        bank.AddCustomer(customerTwo);

        bank.ShowAllAccounts();
    }
}
