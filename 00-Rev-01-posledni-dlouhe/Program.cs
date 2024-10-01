class Program
{
    public static void Main(string[] args)
    {
        string[] slova = { "Karel", "Iva", "Jaromir", "Eva", "Martin" };
        Console.WriteLine(PosledniDlouhe(slova, 5));
        Console.WriteLine(PosledniDlouhe(slova, 7));
        Console.WriteLine(PosledniDlouhe(slova, 12));
    }

    private static string PosledniDlouhe(string[] slova, int limit)
    {
        return slova.LastOrDefault(s => s.Length >= limit) ?? "";
    }
}