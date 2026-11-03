using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KontoNaMonety
{
    internal class Automat
    {
        private int _iloscMonet;
        private readonly List<Moneta> _przyjmowaneMonety;

        public Automat()
        {
            _przyjmowaneMonety = new List<Moneta>();

            _przyjmowaneMonety.Add(new Moneta(5, 5));
            _przyjmowaneMonety.Add(new Moneta(2, 5));
            _przyjmowaneMonety.Add(new Moneta(1, 5));
            _przyjmowaneMonety.Add(new Moneta(0.5m, 5));
            _przyjmowaneMonety.Add(new Moneta(0.2m, 5));
            _przyjmowaneMonety.Add(new Moneta(0.1m, 5));
        }

        // Stwórz metodę WrzucMonete
        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            moneta = moneta.Replace(",", ".");

            // Sprawdzamy czy monetę da się W OGÓLE sparsować na jakiś decimal
            bool czyUdanyParse = decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartoscMonety);

            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety.");
                return;
            }

            // Sprawdź czy monety są z zakresu _przyjmowaneMonety
            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.WartoscMonety == wartoscMonety)
                {
                    if ((objektMonety.Ilosc + 1) > objektMonety.MaxIlosc)
                    {
                        Console.WriteLine($"Moneta o nominale: {objektMonety.WartoscMonety} zł nie zmiania stanu konta.");
                        Console.WriteLine($"Zwrucono monete o nominale: {objektMonety.WartoscMonety} zł");
                        return;
                    }
                    else
                    {
                        konto.Wplac(wartoscMonety);
                        _iloscMonet++;
                        objektMonety.Ilosc++;
                        Console.WriteLine($"Przyjęto monetę: {wartoscMonety} zł");
                        return;
                    }
                }
            }


            Console.WriteLine("Monety o takim nominale nie istnieje!");
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
                    Console.WriteLine("Nieudany odczyt monety.");
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
                                Console.WriteLine($"Moneta o nominale: {objektMonety.WartoscMonety} zł nie zmiania stanu konta.");
                                Console.WriteLine($"Zwrucono monete o nominale: {objektMonety.WartoscMonety} zł");
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
                                Console.WriteLine($"Przyjęto monetę: {wartoscMonety} zł");
                            }
                        }
                    }

                    if (nieznaleziono)
                    {
                        Console.WriteLine("Monety o takim nominale nie istnieje!");
                        zwrucono++;
                    }   
                }
            }

            Console.WriteLine($"Pryzjento: {pryjento}, Zwrucono: {zwrucono}\n");
        }

        public void PokazMonety()
        {
            Console.WriteLine("\nMonety w automacie:");

            decimal suma = 0;

            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.Ilosc > 0)
                {
                    Console.WriteLine($"  Nominał: {objektMonety.WartoscMonety} zł, Ilosc: {objektMonety.Ilosc}");
                    suma += (objektMonety.Ilosc * objektMonety.WartoscMonety);
                }
            }

            Console.WriteLine($"Suma: {suma} zł");
        }
    }
}