using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;

        private List<decimal> _historiaWplat;
        private readonly KoloryKonsoli kolory;

        private readonly string _numer; // generowany automatycznie przy tworzeniu konta

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public KontoBankowe()
        {
            _numer = GenerarorRandomowychLiczb(10);

            _historiaWplat = new List<decimal>();

            kolory = new KoloryKonsoli();
        }

        public string StanKonta()
        {
            return $"\nSaldo: {_saldo} zł, Numer konta: {_numer}";
        }

        public void Wplac(decimal kwota)
        {
            _saldo += kwota;

            _historiaWplat.Add(kwota);
        }

        public void PokazHistorieWplat()
        {
            kolory.Konsola("\nHistoria wplat:", ConsoleColor.DarkYellow);

            foreach (decimal wplata in _historiaWplat)
            {
                kolory.Konsola($"  Kwota: {wplata}", ConsoleColor.Yellow);
            }

            kolory.Konsola($"Łąncznie: {_historiaWplat.Count()} wplat", ConsoleColor.DarkYellow);
        }

        public string GenerarorRandomowychLiczb(int dlugosc)
        {
            Random r = new Random();

            string numer = "";

            for (int i = 0; i < dlugosc; i++)
            {
                numer += $"{r.Next(0, 10)}";
            }

            return numer;
        }
    }
}