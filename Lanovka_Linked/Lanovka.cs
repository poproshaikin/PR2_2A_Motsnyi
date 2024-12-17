namespace Lanovka;

internal class Lanovka
{
    public Clovek?[] Lide { get; private set; }
    public int Zatizeni { get; private set; }
    
    public readonly int Nosnost;

    public Lanovka(int delkaLanovky, int nosnost)
    {
        Lide = new Clovek[delkaLanovky];
        Nosnost = nosnost;
    }

    public bool Nastup(Clovek hloupacek)
    {
        if (Lide[0] is not null)
            return false;

        if (Zatizeni + hloupacek.Hmotnost > Nosnost)
            return false;

        Lide[0] = hloupacek;
        return true;
    }

    public Clovek? Vystup()
    {
        if (Lide[^1] is null)
            return null;

        Zatizeni -= Lide[^1]!.Hmotnost;

        Clovek posledni = Lide[^1]!;
        Lide[^1] = null;
        return posledni;
    }

    public void Jed()
    {
        if (Lide[^1] is not null)
            throw new InvalidOperationException();

        for (int i = Lide.Length - 1; i >= 1; i--)
        {
            Lide[i] = Lide[i - 1];
        }

        Lide[0] = null;
    }
}