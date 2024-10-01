namespace _00_Rev_02_prumer_lichych;

class Program
{
    static void Main(string[] args)
    {
        List<int> kladnaLicha = new();
        Console.WriteLine("Uvadejte cisla");

        while (true)
        {
            string vstup = Console.ReadLine()!;
            if (vstup == "stop")
                break;

            bool parsed = int.TryParse(vstup, out int result);

            if (!parsed)
            {
                Console.WriteLine("Je to spatne cislo ale jedem dal");
            }
            else
                if (result % 2 == 1 && result >= 0)
                    kladnaLicha.Add(result);
        }
        
        Console.WriteLine($"Prumer kladnych lichych cisel: {kladnaLicha.Average()}");
    }
}