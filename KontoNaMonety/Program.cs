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

            automat.WrzucMonety(kontoBankowe, "0,5 0,2 abc 0,3 2");

            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");

            kolory.Konsola(kontoBankowe.StanKonta(), ConsoleColor.DarkGreen);

            kontoBankowe.PokazHistorieWplat();

            automat.PokazMonety();
        }
    }
}