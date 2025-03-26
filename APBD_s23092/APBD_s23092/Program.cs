
namespace APBD_s23092
{
    public class Program
    {
        static void Main()
        {
            // Tworzymy kontenerowce
            Kontenerowiec kontenerowiec1 = new Kontenerowiec(25, 100, 5000);
            Kontenerowiec kontenerowiec2 = new Kontenerowiec(30, 120, 7000);

            // Tworzymy produkty
            Produkt produkt1 = new Produkt("Mrożona pizza", RodzajProduktu.Mrozony, false, 2.5, -18); // Produkt niebezpieczny: false
            Produkt produkt2 = new Produkt("Gaz propan-butan", RodzajProduktu.Gaz, true, 20, 30); // Produkt niebezpieczny: true
            Produkt produkt3 = new Produkt("Olej roślinny", RodzajProduktu.Plyn, false, 15, 20); // Produkt niebezpieczny: false
            Produkt produkt4 = new Produkt("Mięso wołowe", RodzajProduktu.Mrozony, false, 30, -18); // Produkt niebezpieczny: false

            // Tworzymy kontenery różnych typów
            Kontener kontener1 = new KontenerChlodniczy(500, 2, 300, 1000, -18, "Mięso");
            Kontener kontener2 = new KontenerNaGaz(1000, 2.5, 200, 1200, 30);
            Kontener kontener3 = new KontenerNaPlyny(700, 2, 250, 800, true);


            // Ładowanie produktów do kontenerów
            kontener1.ZaladujTowar(produkt4); // Zaladuj produkt do kontenera chlodniczego
            kontener2.ZaladujTowar(produkt2); // Zaladuj produkt do kontenera na gaz
            kontener3.ZaladujTowar(produkt3); // Zaladuj produkt do kontenera na plyny

            // Ładowanie kontenerów na statki
            kontenerowiec1.ZaladujKontener(kontener1);
            kontenerowiec1.ZaladujKontener(kontener2);

            kontenerowiec2.ZaladujKontener(kontener3);

            // Wyświetlanie informacji o statkach i ich ładunkach
            Console.WriteLine("Kontenerowiec 1:");
            kontenerowiec1.WyswietlInformacje();
            Console.WriteLine();

            Console.WriteLine("Kontenerowiec 2:");
            kontenerowiec2.WyswietlInformacje();
            Console.WriteLine();

            // Zastąpienie kontenera na statku
            kontenerowiec1.ZaladujKontener(kontener3); // Zastępujemy inny kontener

            // Przenoszenie kontenera między statkami
            kontenerowiec1.PrzeniesKontener(kontenerowiec2, kontener2.NumerSeryjny);

            // Wyświetlanie zaktualizowanych informacji o statkach
            Console.WriteLine("Po przeniesieniu kontenera:");
            Console.WriteLine("Kontenerowiec 1:");
            kontenerowiec1.WyswietlInformacje();
            Console.WriteLine();

            Console.WriteLine("Kontenerowiec 2:");
            kontenerowiec2.WyswietlInformacje();
            Console.WriteLine();

            // Usunięcie produktu z kontenera
            kontener2.OproznijTowar();
            Console.WriteLine("Po oprożnieniu produktu z kontenera na gaz:");
            kontenerowiec1.WyswietlInformacje();
            Console.WriteLine();

            // Usunięcie kontenera ze statku
            kontenerowiec1.UsunKontener(kontener1.NumerSeryjny);
            Console.WriteLine("Po usunięciu kontenera 1 z kontenerowca 1:");
            kontenerowiec1.WyswietlInformacje();
        }
    }
}
