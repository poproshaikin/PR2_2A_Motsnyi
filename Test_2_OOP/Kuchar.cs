namespace Test_2_OOP;

public sealed class Kuchar : Zamestnanec
{
    private string _hotel;
    
    public Kuchar(string name, Pohlavi pohlavi, int mzda, string hotel) : base(name, pohlavi, mzda, povolani: "kuchař")
    {
        _hotel = hotel;
    }

    public override string Pracuj()
    {
        return $"Klepu řízky v hotelu {_hotel}.";
    }
}