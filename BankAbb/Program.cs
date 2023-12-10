using BankATM.Exceptions;
using BankATM.Models;

Bank bank = new Bank();
User user = default;

Console.WriteLine("ATM-e xos gelmisiniz");
do
{
    Console.WriteLine("Zehmet olmasa Pin daxil ederdiz");

    string? pin = Console.ReadLine();

    try
    {
        user = bank.Login(pin);

        bank.Menu(user);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (UserNotFoundException e)
    {
        Console.WriteLine(e.Message);
    }
} while (true);