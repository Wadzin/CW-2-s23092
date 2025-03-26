namespace APBD_s23092
{
    public class KontenerNaGaz : Kontener, IHazardNotifier
    {
        public double Cisnienie { get; }

        public KontenerNaGaz(double wagaWlasna, double wysokosc, double glebokosc, double maksymalnaLadownosc, double cisnienie)
            : base("G", wagaWlasna, wysokosc, glebokosc, maksymalnaLadownosc)
        {
            Cisnienie = cisnienie;
        }

        public override void ZaladujTowar(Produkt produkt)
        {
            if (produkt.CzyNiebezpieczny)
            {
                WyslijNotyfikacje(NumerSeryjny, "Produkt jest niebezpieczny, załadunek może powodować ryzyko.");
            }

            base.ZaladujTowar(produkt);
        }

        public void WyslijNotyfikacje(string numerSeryjny, string wiadomosc)
        {
            Console.WriteLine($"ALERT: {numerSeryjny} - {wiadomosc}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Cisnienie: {Cisnienie} bar";
        }
    }

}