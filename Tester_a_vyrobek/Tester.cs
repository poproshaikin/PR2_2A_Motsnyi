namespace Tester_a_vyrobek;

internal class Tester
{
    public Vyrobek Vzor { get; set; }
    
    private double _tolerance;

    public double Tolerance
    {
        get => _tolerance;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _tolerance = value;
        }
    }

    public Tester(Vyrobek vzor, double tolerance)
    {
        Vzor = vzor ?? throw new ArgumentNullException();
        Tolerance = tolerance;
    }

    public bool Vyhovuje(Vyrobek vyrobek) // 5
    {
        double rozdil = Math.Abs(Vzor.Rozmer - vyrobek.Rozmer);
        double rozdilProcenty = (100 * rozdil) / Vzor.Rozmer;

        return Tolerance > rozdilProcenty;
    }
}