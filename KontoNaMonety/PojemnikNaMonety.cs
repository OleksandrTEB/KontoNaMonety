namespace KontoNaMonety
{
    internal class PojemnikNaMonety
    {
        private List<Moneta> _pojemnikNaMonety;

        public List<Moneta> NowyPojemnik(int maksymalnaIloscKazdegoNominalu)
        {
            List<Moneta> pojemnik = new List<Moneta>();

            pojemnik.Add(new Moneta(5, maksymalnaIloscKazdegoNominalu));
            pojemnik.Add(new Moneta(2, maksymalnaIloscKazdegoNominalu));
            pojemnik.Add(new Moneta(1, maksymalnaIloscKazdegoNominalu));
            pojemnik.Add(new Moneta(0.5m, maksymalnaIloscKazdegoNominalu));
            pojemnik.Add(new Moneta(0.2m, maksymalnaIloscKazdegoNominalu));
            pojemnik.Add(new Moneta(0.1m, maksymalnaIloscKazdegoNominalu));

            return pojemnik;
        }
    }
}
