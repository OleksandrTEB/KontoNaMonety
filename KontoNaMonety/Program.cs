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

            KoloryKonsoli kolory = new KoloryKonsoli();

            kolory.Konsola(kontoBankowe.StanKonta(), ConsoleColor.DarkGreen);

            Bankomat bankomat = new Bankomat();

            bankomat.ZaladujMonety(10, 5);
            bankomat.ZaladujMonety(10, 2);
            bankomat.ZaladujMonety(10, 1);
            bankomat.ZaladujMonety(10, 0.5m);
            bankomat.ZaladujMonety(10, 0.2m);
            bankomat.ZaladujMonety(10, 0.1m);

            bankomat.Wyplac(kontoBankowe, 7.7m);
            bankomat.PokazMonety();
        }
    }
}