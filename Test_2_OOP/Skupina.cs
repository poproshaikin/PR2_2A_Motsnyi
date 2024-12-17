namespace Test_2_OOP;

public class Skupina
{
    private Zamestnanec[] _zamestnanci;

    public string Popis
    {
        get
        {
            int pocetMuzu = SpocitatPodlePohlavi(Pohlavi.Muz);
            int pocetZen = SpocitatPodlePohlavi(Pohlavi.Zena);

            return $"Skupina {pocetMuzu} muzu a {pocetZen} zen";
        }
    }

    public double PrumernaMzda => _zamestnanci.Average(z => z.Mzda);

    public Skupina(IReadOnlyList<Zamestnanec> zamestnanci)
    {
        _zamestnanci = zamestnanci.ToArray();
    }

    public void DoPrace()
    {
        Console.WriteLine($"Pracuje {_zamestnanci.Length} zamestnancu");

        foreach (Zamestnanec z in _zamestnanci)
        {
            Console.WriteLine(z.Pracuj());
        }
    }

    private int SpocitatPodlePohlavi(Pohlavi pohlavi)
    {
        return _zamestnanci.Count(z => z.Pohlavi == pohlavi);
    }
}