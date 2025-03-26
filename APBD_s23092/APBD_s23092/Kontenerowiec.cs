namespace APBD_s23092
{
    public class Kontenerowiec
    {
        public List<Kontener> Kontenery { get; private set; } = new List<Kontener>();
        public double MaksymalnaPredkosc { get; }
        public int MaksymalnaLiczbaKontenerow { get; }
        public double MaksymalnaWagaKontenerow { get; }

        public Kontenerowiec(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWagaKontenerow)
        {
            MaksymalnaPredkosc = maksymalnaPredkosc;
            MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
            MaksymalnaWagaKontenerow = maksymalnaWagaKontenerow;
        }
        
        public void ZaladujKontener(Kontener kontener)
        {
            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
                throw new InvalidOperationException("Przekroczono maksymalną liczbę kontenerów na statku!");

            double aktualnaWaga = Kontenery.Sum(k => k.WagaWlasna + k.MasaLadunku);
            double nowaWaga = aktualnaWaga + kontener.WagaWlasna + kontener.MasaLadunku;

            if (nowaWaga > MaksymalnaWagaKontenerow)
                throw new InvalidOperationException("Przekroczono maksymalną ładowność kontenerowca!");

            Kontenery.Add(kontener);
        }
        
        public void UsunKontener(string numerSeryjny)
        {
            Kontenery.RemoveAll(k => k.NumerSeryjny == numerSeryjny);
        }
        
        public void PrzeniesKontener(Kontenerowiec cel, string numerSeryjny)
        {
            var kontener = Kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener == null)
                throw new InvalidOperationException("Kontener nie istnieje na tym statku!");

            UsunKontener(numerSeryjny);
            cel.ZaladujKontener(kontener);
        }
        
        public void WyswietlInformacje()
        {
            Console.WriteLine($"🚢 Kontenerowiec: Prędkość {MaksymalnaPredkosc} węzłów, Kontenery: {Kontenery.Count}/{MaksymalnaLiczbaKontenerow}, Ładunek: {Kontenery.Sum(k => k.WagaWlasna + k.MasaLadunku)} ton");
            foreach (var kontener in Kontenery)
            {
                Console.WriteLine($"   - {kontener}");
            }
        }
        
        public void OproznijKontenerowiec()
        {
            Kontenery.Clear();
        }
    }
}
