namespace KontoNaMonety
{
    class KoloryKonsoli
    {
        public void Konsola(string tekst, ConsoleColor kolor)
        {
            Console.ForegroundColor = kolor;

            Console.WriteLine(tekst);

            Console.ResetColor();
        }
    }
}
