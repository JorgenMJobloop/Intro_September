public class Bank
{
    private List<Customer> Customers = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
    }

    public void ShowAllAccounts()
    {
        foreach (var customer in Customers)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            customer.DisplayAccounts();
            Console.WriteLine();
        }
    }
}