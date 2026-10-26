using BankAccountApp;
using NUnit.Framework;

namespace BankAccountTests;

[TestFixture]
public class BankAccountBehaviorTests
{
    [Test]
    public void NewAccount_StartsWithZeroBalance()
    {
        var account = new BankAccount();
        Assert.That(account.GetBalance(), Is.EqualTo(0m));
    }

    [Test]
    public void AccountWithOpeningBalance_StoresTheAmount()
    {
        var account = new BankAccount(125m);
        Assert.That(account.GetBalance(), Is.EqualTo(125m));
    }

    [Test]
    public void MultipleDeposits_AddUpCorrectly()
    {
        var account = new BankAccount();
        account.Deposit(40.50m);
        account.Deposit(9.50m);
        Assert.That(account.GetBalance(), Is.EqualTo(50m));
    }

    [TestCase(-5)]
    [TestCase(0)]
    public void Deposit_RejectsNonPositiveAmounts(int amount)
    {
        var account = new BankAccount(20m);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(amount));
        Assert.That(account.GetBalance(), Is.EqualTo(20m));
    }

    [Test]
    public void Withdrawal_DecreasesAvailableBalance()
    {
        var account = new BankAccount(90m);
        account.Withdraw(35m);
        Assert.That(account.GetBalance(), Is.EqualTo(55m));
    }

    [Test]
    public void Withdrawal_CanUseEntireBalance()
    {
        var account = new BankAccount(30m);
        account.Withdraw(30m);
        Assert.That(account.GetBalance(), Is.Zero);
    }

    [TestCase(-1)]
    [TestCase(0)]
    public void Withdrawal_RejectsNonPositiveAmounts(int amount)
    {
        var account = new BankAccount(25m);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(amount));
        Assert.That(account.GetBalance(), Is.EqualTo(25m));
    }

    [Test]
    public void Withdrawal_AboveBalance_ThrowsAndPreservesFunds()
    {
        var account = new BankAccount(60m);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(61m));
        Assert.That(account.GetBalance(), Is.EqualTo(60m));
    }

    [Test]
    public void OpeningBalance_CannotBeNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new BankAccount(-1m));
    }
}
