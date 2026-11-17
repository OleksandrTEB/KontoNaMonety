using System.Drawing;

namespace KontoNaMonety
{
    internal class Bankomat
    {
        private List<Moneta> _pojemnik;
        private PojemnikNaMonety _tworzeniePojemnika;
        private KoloryKonsoli kolory;

        public Bankomat()
        {
            _tworzeniePojemnika = new PojemnikNaMonety();

            _pojemnik = _tworzeniePojemnika.NowyPojemnik(100);

            kolory = new KoloryKonsoli();
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
                        kolory.Konsola("Za dużo monet!", ConsoleColor.DarkRed);
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
                        if (kwota >= moneta.WartoscMonety)
                        {
                            kolory.Konsola($"{moneta.WartoscMonety}", ConsoleColor.Green);
                            kwota -= moneta.WartoscMonety;
                            moneta.Ilosc--;
                        }
                    }

                    kolory.Konsola($"Wyplacono: {pierwszaKwota} zl", ConsoleColor.Green);
                }
            }
            else
            {
                kolory.Konsola("Nieudana wypłata, niewystarcza środków na koncie!", ConsoleColor.DarkRed);
            }
        }

        public bool CzyDaSieWyplacic(decimal kwota)
        {
            List<Moneta> _pojemnikDoLiczenia = new List<Moneta>();

            foreach(Moneta moneta in _pojemnik)
            {
                _pojemnikDoLiczenia.Add(moneta);
            }

            foreach(Moneta moneta in _pojemnikDoLiczenia)
            {
                if (kwota >= moneta.WartoscMonety)
                {
                    if (moneta.Ilosc > 0)
                    {
                        kwota -= moneta.WartoscMonety;
                        moneta.Ilosc--;
                    }
                    else
                    {
                        kolory.Konsola("Niewystarcza srodkuw w bankomacie!", ConsoleColor.DarkRed);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
