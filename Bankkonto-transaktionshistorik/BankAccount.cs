using System;
using System.Collections.Generic;

class BankAccount
{
    private decimal balance;
    private List<string> transactions;

    public BankAccount()
    {
        balance = 0;
        transactions = new List<string>();
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        balance += amount;
        transactions.Add($"Deposit: {amount} kr");
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be greater than zero.");
            return false;
        }

        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
            return false;
        }

        balance -= amount;
        transactions.Add($"Withdrawal: {amount} kr");
        return true;
    }

    public void Transfer(BankAccount recipient, decimal amount)
    {
        if (recipient == null)
            throw new ArgumentNullException(nameof(recipient));

        if (Withdraw(amount))
            recipient.Deposit(amount);
    }

    public void ShowTransactions()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions.");
            return;
        }

        foreach (string transaction in transactions)
            Console.WriteLine(transaction);
    }
}