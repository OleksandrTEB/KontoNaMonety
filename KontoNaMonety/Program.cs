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

            automat.WrzucMonete(kontoBankowe, "0,5");
            automat.WrzucMonete(kontoBankowe, "0,01");
            automat.WrzucMonete(kontoBankowe, "0,01");
            automat.WrzucMonete(kontoBankowe, "0,02");

            automat.WrzucMonete(kontoBankowe, "0,03");

            automat.WrzucMonete(kontoBankowe, "abc");

            // Wyświetlamy stan konta (jeszcze nie zrobione)
            Console.WriteLine(kontoBankowe.StanKonta());
            automat.PokazMonety();

            KontoBankowe noweKontoBankowe = new KontoBankowe();
            Console.WriteLine(noweKontoBankowe.StanKonta());
        }
    }
}