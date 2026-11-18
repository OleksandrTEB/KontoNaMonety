namespace KontoNaMonety
{
    class Moneta
    {
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
    }
}
