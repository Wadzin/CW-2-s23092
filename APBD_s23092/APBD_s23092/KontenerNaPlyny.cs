namespace APBD_s23092
{
    public class KontenerNaPlyny : Kontener, IHazardNotifier
    {
        public bool JestNiebezpieczny { get; }

        public KontenerNaPlyny(double wagaWlasna, double wysokosc, double glebokosc, double maksymalnaLadownosc,
            bool jestNiebezpieczny)
            : base("L", wagaWlasna, wysokosc, glebokosc, maksymalnaLadownosc)
        {
            JestNiebezpieczny = jestNiebezpieczny;
        }

        public override void ZaladujTowar(Produkt produkt)
        {
            double limit = JestNiebezpieczny ? MaksymalnaLadownosc * 0.5 : MaksymalnaLadownosc * 0.9;

            if (MasaLadunku + produkt.Waga > limit)
            {
                WyslijNotyfikacje(NumerSeryjny, "Przekroczono dopuszczalny poziom załadunku");
                throw new OverfillException("OverfillException: Niebezpieczna operacja");
            }

            MasaLadunku += produkt.Waga;
            Produkty.Add(produkt);
        }

        public void WyslijNotyfikacje(string numerSeryjny, string wiadomosc)
        {
            Console.WriteLine($"ALERT: {numerSeryjny} - {wiadomosc}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Niebezpieczny: {JestNiebezpieczny}";
        }
    }

}