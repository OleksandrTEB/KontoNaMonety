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

            _przyjmowaneMonety.Add(new Moneta(0.01m));
            _przyjmowaneMonety.Add(new Moneta(0.02m));
            _przyjmowaneMonety.Add(new Moneta(0.05m));
            _przyjmowaneMonety.Add(new Moneta(0.1m));
            _przyjmowaneMonety.Add(new Moneta(0.2m));
            _przyjmowaneMonety.Add(new Moneta(0.5m));
            _przyjmowaneMonety.Add(new Moneta(1));
            _przyjmowaneMonety.Add(new Moneta(2));
            _przyjmowaneMonety.Add(new Moneta(5));
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
                if (objektMonety.wartoscMonety == wartoscMonety)
                {
                    konto.Wplac(wartoscMonety);
                    _iloscMonet++;
                    objektMonety.ilosc++;
                    Console.WriteLine($"Przyjęto monetę: {wartoscMonety} zł");
                    return;
                }
            }


            Console.WriteLine("Zła moneta.");
        }

        public void PokazMonety()
        {
            decimal suma = 0;

            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                for (int i = 0; i < objektMonety.ilosc; i++)
                {
                    suma += objektMonety.wartoscMonety;
                }
            }

            foreach (Moneta objektMonety in _przyjmowaneMonety)
            {
                if (objektMonety.ilosc > 0)
                {
                    Console.WriteLine($"Nominał: {objektMonety.wartoscMonety} zł, Ilosc: {objektMonety.ilosc}");
                }
            }

            Console.WriteLine($"Suma: {suma} zł");
        }
    }
}