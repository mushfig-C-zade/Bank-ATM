namespace BankATM.Models;

public static class BankMessages
{
    public const string Deducted10AZNFromBalance = "Balansinizdan 10 azn cixildi";
    public const string Deducted20AZNFromBalance = "Balansinizdan 20 azn cixildi";
    public const string Deducted50AZNFromBalance = "Balansinizdan 50 azn cixildi";
    public const string Deducted100AZNFromBalance = "Balansinizdan 100 azn cixildi";
    public static string DeductedEnteredAZNFromBalance(decimal money) => $"Balansinizdan {money} azn cixildi";
}
