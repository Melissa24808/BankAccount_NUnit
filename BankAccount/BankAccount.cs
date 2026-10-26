namespace BankAccountApp;

public class BankAccount
{
    private decimal _balance;

    public BankAccount(decimal openingBalance = 0m)
    {
        if (openingBalance < 0m)
            throw new ArgumentOutOfRangeException(nameof(openingBalance), "Opening balance cannot be negative.");

        _balance = openingBalance;
    }

    public void Deposit(decimal amount)
    {
        EnsurePositiveAmount(amount);
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        EnsurePositiveAmount(amount);
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
    }

    public decimal GetBalance() => _balance;

    private static void EnsurePositiveAmount(decimal amount)
    {
        if (amount <= 0m)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
    }
}
