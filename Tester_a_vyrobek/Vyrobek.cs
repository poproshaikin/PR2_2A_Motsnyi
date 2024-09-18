namespace Tester_a_vyrobek;

internal class Vyrobek
{
    private double _rozmer;

    public double Rozmer
    {
        get => _rozmer;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _rozmer = value;
        }
    }

    public Vyrobek(double rozmer)
    {
        Rozmer = rozmer;
    }
}