using System;

namespace Kolo
{
    class Kolo
    {
        private Punkt srodek;
        private float promien;
        public Kolo(Punkt srodek = null, float promien = 1)
        {
            this.srodek = srodek ?? new Punkt(0, 0);
            if (promien <= 0)
            {
                Console.WriteLine("Podano nieprawidłowy promień, nastąpi wybranie wartości domyślnej!");
                this.promien = 1;
            }
            else
                this.promien = promien;
        }
        public float Srednica => 2 * promien;
        public float Obwod => 2 * (float)Math.PI * promien;
        public float Pole => (float)(Math.PI * Math.Pow(promien, 2));
        public float Promien
        {
            get => promien;
            set
            {
                if (value > 0)
                    promien = value;
                else
                    Console.WriteLine("Podano nieprawidłowy promień, zmiana została odrzucona!");
            }
        }
        public void Przesun(float a, float b)
        {
            srodek.Przesun(a, b);
        }
        public void PrzesunAlt(float a, float b)
        {
            float x, y;
            x = srodek.X + a;
            y = srodek.Y + b;
            srodek = new Punkt(x, y);
        }
        public void Przesun(Punkt p)
        {
            srodek.Przesun(p);
        }
        public void PrzesunAlt(Punkt p)
        {
            srodek = new Punkt(p.X, p.Y);
        }
        private string CreateBorder(int width, char sign)
        {
            string text = "";
            return text.PadLeft(width, sign) + '\n';
        }
        private string CreateFiller(int width, char sign)
        {
            string text = "";
            return sign + text.PadLeft(width - 2, ' ') + sign + '\n';
        }
        private string CreateLine(int width, string value, char sign)
        {
            string text = "";
            return sign + value.PadLeft((width - 2) / 2 + value.Length / 2) + text.PadLeft((width - 1) / 2 - value.Length / 2) + sign + '\n';
        }
        public override string ToString()
        {
            char sign = '*';
            int width = Console.WindowWidth;
            string res = "";
            res += CreateBorder(width, sign);
            res += CreateFiller(width, sign);
            res += CreateLine(width, "Koło", sign);
            res += CreateFiller(width, sign);
            res += CreateLine(width, $"Środek = " + srodek.ToString(), sign);
            res += CreateLine(width, $"Promień = {promien}", sign);
            res += CreateFiller(width, sign);
            res += CreateBorder(width, sign);
            return res;
        }
    }
}