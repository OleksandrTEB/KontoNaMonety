using System.Drawing;

namespace KontoNaMonety
{
    class Moneta
    {
        private KoloryKonsoli _kolory;
        public readonly decimal WartoscMonety;
        public readonly int MaxIlosc;
        public int Ilosc;

        public Moneta(decimal wartoscMonety, int maxIlosc)
        {
            WartoscMonety = wartoscMonety;
            MaxIlosc = maxIlosc;
        }

        public Moneta(Moneta moneta)
        {
            WartoscMonety = moneta.WartoscMonety;
            MaxIlosc = moneta.MaxIlosc;
            Ilosc = moneta.Ilosc;
        }

        public static int IloscMonetWAutomacie(List<Moneta> monety)
        {
            return monety.Sum(moneta => moneta.Ilosc);
        }

        public static void PokazMonetyWpojemniku(List<Moneta> _pojemnik)
        {
            KoloryKonsoli _kolory = new KoloryKonsoli();

            decimal suma = 0;

            foreach (Moneta objektMonety in _pojemnik)
            {
                _kolory.Konsola($"  Nominał: {objektMonety.WartoscMonety} zł, Ilosc: {objektMonety.Ilosc}", ConsoleColor.Blue);
                suma += (objektMonety.Ilosc * objektMonety.WartoscMonety);
            }

            _kolory.Konsola($"Ilosc: {Moneta.IloscMonetWAutomacie(_pojemnik)}", ConsoleColor.DarkBlue);
            _kolory.Konsola($"Suma: {suma} zł", ConsoleColor.DarkBlue);
        }
    }
}
