namespace APBD_s23092
{
    public class KontenerChlodniczy : Kontener
    {
        public double Temperatura { get; private set; }
        public string RodzajProduktu { get; private set; }

        private static readonly Dictionary<string, double> MinimalneTemperatury = new Dictionary<string, double>
        {
            { "Mięso", -18 },
            { "Ryby", -20 },
            { "Lody", -25 }
        };

        public KontenerChlodniczy(double wagaWlasna, double wysokosc, double glebokosc, double maksymalnaLadownosc, double temperatura, string rodzajProduktu)
            : base("C", wagaWlasna, wysokosc, glebokosc, maksymalnaLadownosc)
        {
            if (MinimalneTemperatury.ContainsKey(rodzajProduktu) && temperatura < MinimalneTemperatury[rodzajProduktu])
            {
                throw new InvalidOperationException($"Temperatura kontenera dla produktu '{rodzajProduktu}' nie może być wyższa niż {MinimalneTemperatury[rodzajProduktu]}°C!");
            }

            RodzajProduktu = rodzajProduktu;
            Temperatura = temperatura;
        }

        public void UstawTemperature(double temperatura)
        {
            if (MinimalneTemperatury.ContainsKey(RodzajProduktu) && temperatura < MinimalneTemperatury[RodzajProduktu])
            {
                throw new InvalidOperationException($"Temperatura kontenera dla produktu '{RodzajProduktu}' nie może być wyższa niż {MinimalneTemperatury[RodzajProduktu]}°C!");
            }

            Temperatura = temperatura;
        }

        public override void ZaladujTowar(Produkt produkt)
        {
            if (produkt.Temperatura > Temperatura)
            {
                throw new InvalidOperationException($"Temperatura produktu '{produkt.Nazwa}' jest wyższa niż temperatura kontenera!");
            }

            base.ZaladujTowar(produkt);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Temperatura: {Temperatura}°C, Produkt: {RodzajProduktu}";
        }
    }

}