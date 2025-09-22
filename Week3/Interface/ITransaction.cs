/// <summary>
/// An interface for a class that handles banking transactions
/// </summary>
public interface ITransaction
{
    /// <summary>
    /// Execute a transaction within a bank account
    /// </summary>
    /// <param name="amount">The amount of money</param>
    void ExecuteTransaction(Account accountFrom, Account accountTo, double amount);
}