using System;
using System.Collections.Generic;
using System.Linq;
using Test_2_OOP;

class Program {
    public static void Main (string[] args) 
    {
        Test();
    }
    public static void Test()
    {
        Ucetni franta = new Ucetni("František", Pohlavi.Muz, 31000);
        Ucetni alena  = new Ucetni("Alena", Pohlavi.Zena, 33000);
      
        Kuchar martin = new Kuchar("Martin", Pohlavi.Muz, 25000, "Modrá hvězda");
        Kuchar jirina = new Kuchar("Jiřina", Pohlavi.Zena, 27000, "Barrique");
        Kuchar tomas  = new Kuchar("Tomáš", Pohlavi.Muz, 29000, "Sommelier");
        Console.WriteLine(tomas); //vypíše něco jako "Jmenuji se Tomáš a jsem muž"
      
        Zamestnanec[] lide = { franta, alena, martin, jirina, tomas };
      
        Skupina parta = new Skupina(lide);
      
        Console.WriteLine(parta.Popis); //vypíše "Skupina 3 mužů a 2 žen"
        Console.WriteLine(parta.PrumernaMzda); //vypíše "29000"
      
        Console.WriteLine();
        parta.DoPrace();
      
        // Poslední příkaz vypíše      
        // Pracuje 5 zaměstanců
        // František: Kontroluji faktury
        // Alena: Kontroluji faktury
        // Martin: Klepu řízky v hotelu Modrá hvězda
        // Jiřina: Klepu řízky v hotelu Barrique
        // Tomáš: Klepu řízky v hotelu Sommelier
            
    }
}

//zde vložte vaše třídy a interface
//nevkládejte kód s namespace