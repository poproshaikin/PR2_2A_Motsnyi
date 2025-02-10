namespace Vozejk;

class Voziky
{
    const int pocet_vozejku = 10;
    const int cas_start = 0;
    const int cas_konec = 12 * 60;
    const int max_zakazniku_za_minutu = 3;
    const int max_zakazniku_celkove = 50;
    const int min_nakup = 5;
    const int max_nakup = 45;
    

    static readonly Random _random = new Random(123456);
    
    
    static readonly List<Vozik> _vozikyCelkem = new List<Vozik>();
    
    static readonly Stack<Vozik> _volneVoziky = new Stack<Vozik>();
    
    static readonly Queue<Clovek> _fronta = new Queue<Clovek>();
    
    static readonly List<Clovek> _lideNaNakupu = new List<Clovek>();
    

    static int _cas = cas_start;

    static void Main()
    {   
        InitStack();
        
        // hlavni smycka
        while (true)
        {
            // zkontrolovat u kazdyho cloveka zda neukoncil nakup
            for (int i = 0; i < _lideNaNakupu.Count; i++)
            {
                var clovek = _lideNaNakupu[i];
                if (clovek.Vozik is null)
                    throw new InvalidOperationException("something went wrong");
                
                // pokud nastal cas ukonceni nakupu
                if (_cas >= clovek.CasKonceNakupu)
                {
                    // pridat vozik do stacku
                    _volneVoziky.Push(clovek.Vozik);
                    // smazat cloveka
                    _lideNaNakupu.Remove(clovek);
                    
                    Log($"Clovek {clovek.Id} ukoncil nakup s vozikem {clovek.Vozik.Id}. Nakup trval: {clovek.CasNaNakup}");
                }
            }
            
            // pokud obchod neuzavrel
            if (_cas < cas_konec && _lideNaNakupu.Count < max_zakazniku_celkove)
            {
                int noveLidi = _random.Next(0, max_zakazniku_za_minutu);
                for (int i = 0; i < noveLidi; i++)
                {
                    if (_fronta.Count >= max_zakazniku_celkove)
                        break;
                    
                    int casNaNakup = _random.Next(min_nakup, max_nakup + 1);

                    Clovek clovek = new Clovek(casNaNakup, casNaNakup + _cas);
                    
                    if (_volneVoziky.Count > 0)
                    {
                        clovek.Vozik = _volneVoziky.Pop();
                        _lideNaNakupu.Add(clovek);
                        Log($"Clovek {clovek.Id} vzal si kosik {clovek.Vozik.Id} a sel na nakup");
                    }
                    else
                    {
                        _fronta.Enqueue(clovek);
                        Log($"Clovek {clovek.Id} sel do fronty");
                    }
                }
            }

            AtCekajiciVezmeVozik();

            InkrementovatCas();
            
            // Log($"Volne voziky: {_volneVoziky.Count}");
            // Log($"Lide ve fronte: {_fronta.Count}");
            // Log($"Lode na nakupu: {_lideNaNakupu.Count}");
            //
            // foreach (var clovek in _lideNaNakupu)
            // {
            //     Log($" Cas do konce nakupu u cloveka {clovek.Id} -> {clovek.CasKonceNakupu - _cas}");
            // }

            // pokud po uzavreni nikdo v obchode nezustal
            if (_cas >= cas_konec && _lideNaNakupu.Count == 0)
                break;
            
            Thread.Sleep(100);
        }
        
        VypsatStatistiku();
    }

    static void ZkontrolovatUkonceniNakupu()
    {
        // zkontrolovat u kazdyho cloveka zda neukoncil nakup
        for (int i = 0; i < _lideNaNakupu.Count; i++)
        {
            var clovek = _lideNaNakupu[i];
            if (clovek.Vozik is null)
                throw new InvalidOperationException("something went wrong");
                
            // pokud nastal cas ukonceni nakupu
            if (_cas == clovek.CasKonceNakupu)
            {
                // pridat vozik do stacku
                _volneVoziky.Push(clovek.Vozik);
                // smazat cloveka
                _lideNaNakupu.Remove(clovek);
                    
                Log($"Clovek {clovek.Id} ukoncil nakup s vozikem {clovek.Vozik.Id}. Nakup trval: {clovek.CasNaNakup}");
            }
        }
    }
    
    static void AtCekajiciVezmeVozik()
    {
        // jestli se uvolnil nejaky vozik a ve fronte nekdo stoji
        while (_volneVoziky.Count > 0 && _fronta.Count > 0)
        {
            // odebrat cloveka z fronty
            Clovek clovek = _fronta.Dequeue();
            // clovek si vezme vozik
            clovek.Vozik = _volneVoziky.Pop();
            // clovek pujde na nakup
            _lideNaNakupu.Add(clovek);
            Log($"Clovek {clovek.Id} dockal se volneho voziku {clovek.Vozik.Id} a sel nakupovat");
        }
    }
    
    static void InkrementovatCas()
    {
        _cas++;
        foreach (var vozik in _vozikyCelkem)
        {
            vozik.CelkemVProvozu++;
        }
    }
    
    static void VypsatStatistiku()
    {
        foreach (var vozik in _vozikyCelkem)
        {
            Log($"Vozik {vozik.Id} -> {vozik.CelkemVProvozu} minut");
        }
    }

    static Clovek[] VygenerovatLidi()
    {
        if (_lideNaNakupu.Count >= max_zakazniku_celkove)
            return [];
        
        int pocet = _random.Next(0, max_zakazniku_za_minutu + 1);
        var lidi = new Clovek[pocet];
        
        for (int i = 0; i < pocet; i++)
        {
            lidi[i] = VygenerovatCloveka();
        }

        return lidi;
    }

    static void InitStack()
    {
        for (int i = 0; i < pocet_vozejku; i++)
        {
            var novyVozik = new Vozik();
            _vozikyCelkem.Add(novyVozik);
            _volneVoziky.Push(novyVozik);
        }
    }

    static Clovek VygenerovatCloveka()
    {
        int casNaNakup = _random.Next(min_nakup, max_nakup + 1);
        return new Clovek(casNaNakup, casNaNakup + _cas);
    }

    static void Log(string s)
    {
        Console.WriteLine($" {_cas}: {s}");
    }
}

class Clovek
{
    private static int _posledniId = 0;
    
    public int Id { get; }
    
    public int CasNaNakup { get; }
    public int CasKonceNakupu { get; }
    
    public Vozik? Vozik { get; set; }

    public Clovek(int casNaNakup, int casKonceNakupu)
    {
        Id = _posledniId++;
        CasNaNakup = casNaNakup;
        CasKonceNakupu = casKonceNakupu;
    }
}

class Vozik
{
    private static int _posledniId = 0;
    
    public int Id { get; }
    public int CelkemVProvozu { get; set; }  // minut

    public Vozik()
    {
        Id = _posledniId++;
        CelkemVProvozu = 0;
    }
}