using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace KontoNaMonety
{
    internal class Automat
    {
        private int _iloscMonet;
        private readonly List<Moneta> _przyjmowaneMonety;
        private readonly KoloryKonsoli kolory;

        public Automat()
        {
            _przyjmowaneMonety = new List<Moneta>();

            _przyjmowaneMonety.Add(new Moneta(5, 5));
            _przyjmowaneMonety.Add(new Moneta(2, 5));
            _przyjmowaneMonety.Add(new Moneta(1, 5));
            _przyjmowaneMonety.Add(new Moneta(0.5m, 5));
            _przyjmowaneMonety.Add(new Moneta(0.2m, 5));
            _przyjmowaneMonety.Add(new Moneta(0.1m, 5));

            kolory = new KoloryKonsoli();
        }

        // Stwórz metodę WrzucMonete
        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            moneta = moneta.Replace(",", ".");

            // Sprawdzamy czy monetę da się W OGÓLE sparsować na jakiś decimal
            bool czyUdanyParse = decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartoscMonety);

            if (!czyUdanyParse)
            {
                kolory.Konsola("Nieudany odczyt monety.", ConsoleColor.DarkRed);
                return;
            }

            // Sprawdź czy monety są z zakresu _przyjmowaneMonety
            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.WartoscMonety == wartoscMonety)
                {
                    if ((objektMonety.Ilosc + 1) > objektMonety.MaxIlosc)
                    {
                        kolory.Konsola($"Moneta o nominale: {objektMonety.WartoscMonety} zł nie zmiania stanu konta.", ConsoleColor.Red);
                        kolory.Konsola($"Zwrucono monete o nominale: {objektMonety.WartoscMonety} zł", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        konto.Wplac(wartoscMonety);
                        _iloscMonet++;
                        objektMonety.Ilosc++;
                        kolory.Konsola($"Przyjęto monetę: {wartoscMonety} zł", ConsoleColor.Green);
                        return;
                    }
                }
            }

            kolory.Konsola("Monety o takim nominale nie istnieje!", ConsoleColor.DarkRed);
        }

        public void WrzucMonety(KontoBankowe konto, string monety)
        {
            monety = monety.Replace(",", ".");

            string[] tablicaMonet = monety.Split(' ');

            int pryjento = 0, zwrucono = 0;

            foreach (string moneta in tablicaMonet)
            {
                // Sprawdzamy czy monetę da się W OGÓLE sparsować na jakiś decimal
                bool czyUdanyParse = decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartoscMonety);

                if (!czyUdanyParse)
                {
                    kolory.Konsola("Nieudany odczyt monety.", ConsoleColor.DarkRed);
                    zwrucono++;
                }
                else
                {
                    bool nieznaleziono = true;

                    // Sprawdź czy monety są z zakresu _przyjmowaneMonety
                    foreach (Moneta objektMonety in _przyjmowaneMonety)
                    {
                        if (objektMonety.WartoscMonety == wartoscMonety)
                        {
                            if ((objektMonety.Ilosc + 1) > objektMonety.MaxIlosc)
                            {
                                kolory.Konsola($"Moneta o nominale: {objektMonety.WartoscMonety} zł nie zmiania stanu konta.", ConsoleColor.Red);
                                kolory.Konsola($"Zwrucono monete o nominale: {objektMonety.WartoscMonety} zł", ConsoleColor.Red);
                                nieznaleziono = false;
                                zwrucono++;
                            }
                            else
                            {
                                nieznaleziono = false;
                                konto.Wplac(wartoscMonety);
                                _iloscMonet++;
                                pryjento++;
                                objektMonety.Ilosc++;
                                kolory.Konsola($"Przyjęto monetę: {wartoscMonety} zł", ConsoleColor.Green);
                            }
                        }
                    }

                    if (nieznaleziono)
                    {
                        kolory.Konsola("Monety o takim nominale nie istnieje!", ConsoleColor.DarkRed);
                        zwrucono++;
                    }   
                }
            }

            kolory.Konsola($"Pryzjento: {pryjento}, Zwrucono: {zwrucono}\n", ConsoleColor.Magenta);
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

            kolory.Konsola($"Suma: {suma} zł", ConsoleColor.DarkBlue);
        }
    }
}