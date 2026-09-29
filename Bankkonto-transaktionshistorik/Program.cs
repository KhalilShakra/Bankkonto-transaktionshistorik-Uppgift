using System;

class Program
{
    static void Main()
    {
        BankAccount anna = new BankAccount();
        BankAccount erik = new BankAccount();

        anna.Deposit(500);
        anna.Deposit(200);
        anna.Withdraw(100);
        anna.Withdraw(1000);

        try
        {
            anna.Deposit(0);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        erik.Deposit(300);
        erik.Withdraw(-50);
        anna.Transfer(erik, 150);
        erik.Transfer(anna, 5000);

        Console.WriteLine();
        Console.WriteLine("Anna");
        anna.ShowTransactions();
        Console.WriteLine($"Balance: {anna.Balance} kr");

        Console.WriteLine();
        Console.WriteLine("Erik");
        erik.ShowTransactions();
        Console.WriteLine($"Balance: {erik.Balance} kr");
    }
}