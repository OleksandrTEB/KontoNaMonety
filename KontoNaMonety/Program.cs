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

            automat.WrzucMonety(kontoBankowe, "0,5 0,2 abc 0,3 2");

            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "1");

            kontoBankowe.PokazHistorieWplat();

            automat.PokazMonety();
        }
    }
}