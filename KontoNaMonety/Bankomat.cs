using System.Drawing;

namespace KontoNaMonety
{
    internal class Bankomat
    {
        private List<Moneta> _pojemnik;
        private List<Moneta> _wydaneMonety;
        private PojemnikNaMonety _tworzeniePojemnika;
        private KoloryKonsoli _kolory;
        private int _iloscKazdegoNominaluWPojemniku;

        public Bankomat()
        {
            _iloscKazdegoNominaluWPojemniku = 100;

            _tworzeniePojemnika = new PojemnikNaMonety();

            _wydaneMonety = _tworzeniePojemnika.NowyPojemnik(_iloscKazdegoNominaluWPojemniku);

            _pojemnik = _tworzeniePojemnika.NowyPojemnik(_iloscKazdegoNominaluWPojemniku);

            _kolory = new KoloryKonsoli();
        }

        public void ZaladujMonety(int ilosc, decimal nominal)
        {
            foreach (Moneta objektMonety in _pojemnik)
            {
                if (objektMonety.WartoscMonety == nominal)
                {
                    if ((objektMonety.Ilosc + ilosc) <= objektMonety.MaxIlosc)
                    {
                        objektMonety.Ilosc += ilosc;
                        return;
                    }
                    else
                    {
                        _kolory.Konsola("Za dużo monet!", ConsoleColor.DarkRed);
                        return;
                    }
                }
            }
        }

        public void Wyplac(KontoBankowe konto, decimal kwota)
        {
            if (konto.Wyplac(kwota))
            {
                if (CzyDaSieWyplacic(kwota))
                {
                    decimal pierwszaKwota = kwota;

                    foreach (Moneta moneta in _pojemnik)
                    {
                        while (kwota >= moneta.WartoscMonety && moneta.Ilosc > 0)
                        {
                            kwota -= moneta.WartoscMonety;
                            moneta.Ilosc--;

                            Moneta znalezionaMoneta = _wydaneMonety.Find(m => m.WartoscMonety == moneta.WartoscMonety);
                            znalezionaMoneta.Ilosc++;
                        }
                    }

                    _kolory.Konsola($"Wyplacono: {pierwszaKwota} zl", ConsoleColor.Green);
                }
            }
            else
            {
                _kolory.Konsola("Nieudana wypłata, niewystarcza środków na koncie!", ConsoleColor.DarkRed);
            }
        }

        public bool CzyDaSieWyplacic(decimal kwota)
        {
            List<Moneta> pojemnikDoLiczenia = new List<Moneta>();

            foreach(Moneta m in _pojemnik)
            {
                pojemnikDoLiczenia.Add(new Moneta(m));
            }

            foreach(Moneta moneta in pojemnikDoLiczenia)
            {
                if (moneta.Ilosc > 0)
                {
                    while (kwota >= moneta.WartoscMonety && moneta.Ilosc > 0)
                    {
                        kwota -= moneta.WartoscMonety;
                        moneta.Ilosc--;
                    }
                }
            }

            if (kwota > 0)
            {
                _kolory.Konsola("Niewystarcza srodkuw w bankomacie!", ConsoleColor.DarkRed);
                return false;
            }

            return true;
        }

        public void WydawaneMonety()
        {
            _kolory.Konsola("\nMonety w wydane:", ConsoleColor.DarkBlue);


            foreach (Moneta objektMonety in _wydaneMonety)
            {
                if (objektMonety.Ilosc > 0)
                {
                    _kolory.Konsola($"  Nominał: {objektMonety.WartoscMonety} zł, Ilosc: {objektMonety.Ilosc}", ConsoleColor.Blue);
                }
            }
        }

        public void PokazMonety()
        {
            _kolory.Konsola("\nMonety w bankomacie:", ConsoleColor.DarkBlue);

            Moneta.PokazMonetyWpojemniku(_pojemnik);
        }
    }
}
