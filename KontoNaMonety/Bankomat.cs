using System.Drawing;

namespace KontoNaMonety
{
    internal class Bankomat
    {
        private List<Moneta> _pojemnikNaMonety;
        private Automat _automat;
        private readonly KoloryKonsoli kolory;
        private int _iloscKazdegoNominalu;

        public Bankomat()
        {
            kolory = new KoloryKonsoli();
            _pojemnikNaMonety = new List<Moneta>();
            _automat = new Automat();

            _iloscKazdegoNominalu = 10;

            _pojemnikNaMonety.Add(new Moneta(5, _iloscKazdegoNominalu));
            _pojemnikNaMonety.Add(new Moneta(2, _iloscKazdegoNominalu));
            _pojemnikNaMonety.Add(new Moneta(1, _iloscKazdegoNominalu));
            _pojemnikNaMonety.Add(new Moneta(0.5m, _iloscKazdegoNominalu));
            _pojemnikNaMonety.Add(new Moneta(0.2m, _iloscKazdegoNominalu));
            _pojemnikNaMonety.Add(new Moneta(0.1m, _iloscKazdegoNominalu));
        }

        public void ZaladujMonety(int ilosc, decimal nominal)
        {
            foreach (Moneta objektMonety in _pojemnikNaMonety)
            {
                if (objektMonety.WartoscMonety == nominal)
                {
                    objektMonety.Ilosc += ilosc;
                    return;
                }
            }

            kolory.Konsola("Monety o takim nominale nie istnieje!", ConsoleColor.DarkRed);
        }

        public void Wyplac(KontoBankowe konto, decimal kwota)
        {

        }
    }
}
