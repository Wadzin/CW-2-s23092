namespace APBD_s23092
{
    public abstract class Kontener
    {
        public string Typ { get; }
        public string NumerSeryjny { get; }
        public double MasaLadunku { get; protected set; }
        public double WagaWlasna { get; }
        public double Wysokosc { get; }
        public double Glebokosc { get; }
        public double MaksymalnaLadownosc { get; }
        public List<Produkt> Produkty { get; private set; }

        protected Kontener(string typ, double wagaWlasna, double wysokosc, double glebokosc, double maksymalnaLadownosc)
        {
            Typ = typ;
            NumerSeryjny = KontenerNumerator.GenerujNumer(typ);
            MasaLadunku = 0;
            WagaWlasna = wagaWlasna;
            Wysokosc = wysokosc;
            Glebokosc = glebokosc;
            MaksymalnaLadownosc = maksymalnaLadownosc;
            Produkty = new List<Produkt>();
        }
        
        public virtual void ZaladujTowar(Produkt produkt)
        {
            if (MasaLadunku + produkt.Waga > MaksymalnaLadownosc)
            {
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera!");
            }

            MasaLadunku += produkt.Waga;
            Produkty.Add(produkt);
        }
        public virtual void OproznijTowar()
        {
            MasaLadunku = 0;
            Produkty.Clear();
        }

        public override string ToString()
        {
            return $"{NumerSeryjny}: {Produkty.Count} produktów, {MasaLadunku} kg ładunku";
        }
    }

}