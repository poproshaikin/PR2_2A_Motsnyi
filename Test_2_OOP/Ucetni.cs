namespace Test_2_OOP;

public sealed class Ucetni : Zamestnanec
{
    public Ucetni(string name, Pohlavi pohlavi, int mzda) : base(name, pohlavi, mzda, povolani: "účetní")
    {
    }

    public override string Pracuj()
    {
        return "Kontroluji faktury";
    }
}