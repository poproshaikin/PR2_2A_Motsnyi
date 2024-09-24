namespace Lanovka;

internal class Clovek
{
    public string Jmeno { get; }
    public int Hmotnost { get; }

    public Clovek(string jmeno, int hmotnost)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(hmotnost);
        ArgumentNullException.ThrowIfNull(jmeno);
        
        Jmeno = jmeno;
        Hmotnost = hmotnost;
    }
}