namespace BankATM.Models;

public class History(string operation)
{
    public DateTimeOffset DateTime { get; } = DateTimeOffset.UtcNow;
    public string Operation { get; set; } = operation;
}
