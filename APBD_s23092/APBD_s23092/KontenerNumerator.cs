namespace APBD_s23092
{
    public static class KontenerNumerator
    {
        private static readonly Dictionary<string, int> Liczniki = new Dictionary<string, int>();

        public static string GenerujNumer(string typ)
        {
            if (!Liczniki.ContainsKey(typ))
                Liczniki[typ] = 0;

            Liczniki[typ]++;
            return $"KON-{typ}-{Liczniki[typ]}";
        }
    }
}