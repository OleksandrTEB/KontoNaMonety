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
    }
}
