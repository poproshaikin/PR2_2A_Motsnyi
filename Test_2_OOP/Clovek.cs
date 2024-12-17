namespace Test_2_OOP;

public class Clovek
{
    public string Name { get; protected set; }
    public Pohlavi Pohlavi { get; protected set; }

    public Clovek(string name, Pohlavi pohlavi)
    {
        Name = name;
        Pohlavi = pohlavi;
    }

    public override string ToString()
    {
        return $"Jmenuji se {Name} a jsem {Pohlavi}";
    }
}