namespace Test_2_OOP;

public abstract class Zamestnanec : Clovek
{
    public int Mzda { get; protected set; }
    public string Povolani { get; protected set; }

    protected Zamestnanec(string name, Pohlavi pohlavi, int mzda, string povolani) : base(name, pohlavi)
    {
        Mzda = mzda;
        Povolani = povolani;
    }

    public abstract string Pracuj();
}