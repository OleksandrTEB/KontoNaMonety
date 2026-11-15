using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace KontoNaMonety
{
    internal class Automat
    {
        private readonly List<Moneta> _przyjmowaneMonety;
        private readonly KoloryKonsoli kolory;
        private readonly int _iloscKazdegoNominalu = 5;

        public Automat()
        {
            _przyjmowaneMonety = new List<Moneta>();

            _przyjmowaneMonety.Add(new Moneta(5, _iloscKazdegoNominalu));
            _przyjmowaneMonety.Add(new Moneta(2, _iloscKazdegoNominalu));
            _przyjmowaneMonety.Add(new Moneta(1, _iloscKazdegoNominalu));
            _przyjmowaneMonety.Add(new Moneta(0.5m, _iloscKazdegoNominalu));
            _przyjmowaneMonety.Add(new Moneta(0.2m, _iloscKazdegoNominalu));
            _przyjmowaneMonety.Add(new Moneta(0.1m, _iloscKazdegoNominalu));

            kolory = new KoloryKonsoli();
        }

        // Stwórz metodę WrzucMonete
        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            if (!ParsowanieMonety(moneta, out decimal wartoscMonety))
            {
                return;
            }

            if (CzyJestTakaMoneta(wartoscMonety))
            {
                konto.Wplac(wartoscMonety);
            }            
        }

        public void WrzucMonety(KontoBankowe konto, string monety)
        {
            string[] tablicaMonet = monety.Split(' ');

            int pryjento = 0, zwrucono = 0;

            foreach (string moneta in tablicaMonet)
            {
                if (!ParsowanieMonety(moneta, out decimal wartoscMonety))
                {
                    zwrucono++;
                    continue;
                }

                if (CzyJestTakaMoneta(wartoscMonety))
                {
                    konto.Wplac(wartoscMonety);
                    pryjento++;
                }
                else
                {
                    zwrucono++;
                }
            }

            kolory.Konsola($"Pryzjento: {pryjento}, Zwrucono: {zwrucono}\n", ConsoleColor.Magenta);
        }

        public bool CzyJestTakaMoneta(decimal moneta)
        {
            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.WartoscMonety == moneta)
                {
                    if ((objektMonety.Ilosc + 1) > objektMonety.MaxIlosc)
                    {
                        kolory.Konsola($"Moneta o nominale: {objektMonety.WartoscMonety} zł nie zmiania stanu konta.", ConsoleColor.Red);
                        kolory.Konsola($"Zwrucono monete o nominale: {objektMonety.WartoscMonety} zł", ConsoleColor.Red);
                        return false;
                    }
                    else
                    {
                        objektMonety.Ilosc++;
                        kolory.Konsola($"Przyjęto monetę: {moneta} zł", ConsoleColor.Green);
                        return true;
                    }
                }
            }

            kolory.Konsola("Monety o takim nominale nie istnieje!", ConsoleColor.DarkRed);
            return false;
        }

        public bool ParsowanieMonety(string moneta, out decimal wartoscMonety)
        {
            moneta = moneta.Replace(",", ".");

            if (decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out wartoscMonety))
            {
                return true;
            }

            kolory.Konsola("Nieudany odczyt monety.", ConsoleColor.DarkRed);
            return false;
        }

        public void PokazMonety()
        {
            kolory.Konsola("\nMonety w automacie:", ConsoleColor.DarkBlue);

            decimal suma = 0;

            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.Ilosc > 0)
                {
                    kolory.Konsola($"  Nominał: {objektMonety.WartoscMonety} zł, Ilosc: {objektMonety.Ilosc}", ConsoleColor.Blue);
                    suma += (objektMonety.Ilosc * objektMonety.WartoscMonety);
                }
            }

            kolory.Konsola($"Ilosc: {Moneta.IloscMonetWAutomacie(_przyjmowaneMonety)}", ConsoleColor.DarkBlue);
            kolory.Konsola($"Suma: {suma} zł", ConsoleColor.DarkBlue);
        }
    }
}