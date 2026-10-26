# Bank Account — NUnit Practice

A small C# .NET 8 project demonstrating bank account operations and unit testing with NUnit.

## Features

- Deposit positive amounts
- Withdraw positive amounts without overdrawing
- Check the current balance
- Optional opening balance
- Reject invalid amounts with clear exceptions

## Project layout

- `BankAccount/` — application logic
- `BankAccount.Tests/` — NUnit behavior tests

## Run tests

From this folder:

```powershell
dotnet test BankAccount.Tests/BankAccount.Tests.csproj
```

## TDD notes

The intended Red–Green–Refactor cycle is:

1. **Red:** write a failing test for a rule (for example, overdraft protection).
2. **Green:** add the simplest implementation that makes the test pass.
3. **Refactor:** remove duplication (for example, shared positive-amount validation) and rerun tests.

This repository contains the completed code. To document actual TDD history, commit each stage separately while performing it.

## Test coverage

Tests cover starting balance, opening balance, repeated deposits, invalid deposits, successful withdrawals, full withdrawal, invalid withdrawals, overdrafts, and invalid opening balances.
