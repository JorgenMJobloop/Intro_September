public class Transaction : ITransaction
{
    public void ExecuteTransaction(Account accountFrom, Account accountTo, double amount)
    {
        if (accountFrom.Widthdraw(amount))
        {
            accountTo.Deposit(amount);
            Console.WriteLine($"Transacted {amount:C} from {accountFrom.AccountNumber} to {accountTo.AccountNumber}");
        }
        else
        {
            // Using the private helper method to extend the number of attempts when transacting to 3.
            RetryTransaction(accountFrom, accountTo, amount);
        }
    }

    private void RetryTransaction(Account from, Account to, double amount)
    {
        int attempts = 4;
        int count = 0;

        while (attempts <= 4)
        {
            if (!from.Widthdraw(amount))
            {
                count += 1;
                Console.WriteLine("Trying to complete transaction, please wait...");
                to.Deposit(amount);
            }
            else
            {
                Console.WriteLine($"Transacted {amount:C} from {from.AccountNumber} to {to.AccountNumber}");
            }
            if (attempts == count)
            {
                Console.WriteLine("Failed to complete the transaction, please contact the bank!");
                break;
            }
        }
    }
}