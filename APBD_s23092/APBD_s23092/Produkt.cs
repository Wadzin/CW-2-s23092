namespace APBD_s23092;

public class Produkt
{
    public string Nazwa { get; }
    public RodzajProduktu Rodzaj { get; }
    public bool CzyNiebezpieczny { get; }
    public double Waga { get; }
    public double Temperatura { get; }

    public Produkt(string nazwa, RodzajProduktu rodzaj, bool czyNiebezpieczny, double waga, double temperatura)
    {
        Nazwa = nazwa;
        Rodzaj = rodzaj;
        CzyNiebezpieczny = czyNiebezpieczny;
        Waga = waga;
        Temperatura = temperatura;
    }
}