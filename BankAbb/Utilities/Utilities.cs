namespace BankATM.Utilities;

public static class Utilities
{
    public static void Swap(ref char sym1, ref char sym2) => (sym1, sym2) = (sym2, sym1);

}
