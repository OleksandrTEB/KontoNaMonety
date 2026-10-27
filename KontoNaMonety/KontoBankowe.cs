using System;
using System.Collections.Generic;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;

        private readonly string _numer; // generowany automatycznie przy tworzeniu konta

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public KontoBankowe()
        {
            _numer = GenerarorRandomowychLiczb(10);
        }

        public string StanKonta()
        {
            return $"\nSaldo: {_saldo}, Numer konta: {_numer}";
        }

        public void Wplac(decimal kwota)
        {
            _saldo += kwota;
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