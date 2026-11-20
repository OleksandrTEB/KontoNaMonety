namespace KontoNaMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie konta
            KontoBankowe kontoBankowe = new KontoBankowe();

            // Tworzenie automatu do wpłat
            Automat automat = new Automat();

            Bankomat bankomat = new Bankomat();

            KoloryKonsoli kolory = new KoloryKonsoli();



            // Main
            automat.WrzucMonete(kontoBankowe, "5");
            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "2");
            automat.WrzucMonete(kontoBankowe, "1");

            bankomat.ZaladujMonety(10, 5);
            bankomat.ZaladujMonety(10, 2);
            bankomat.ZaladujMonety(10, 1);
            bankomat.ZaladujMonety(2, 0.2m);
            bankomat.ZaladujMonety(6, 0.1m);

            kontoBankowe.StanKonta();

            bankomat.Wyplac(kontoBankowe, 5.5m);

            kontoBankowe.StanKonta();

            bankomat.Wyplac(kontoBankowe, 1000000);

            bankomat.Wyplac(kontoBankowe, 0.7m);

            bankomat.PokazMonety();
        }
    }
}