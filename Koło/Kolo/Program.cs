using System;

namespace Kolo
{
    class Program
    {
        static void Main(string[] args)
        {
            Kolo k1 = new Kolo(new Punkt(2.5f, 8.3f), 6);
            Kolo k2 = new Kolo(null, -5);
            Punkt p = new Punkt(-3, 14);
            k1.Przesun(-12, 2);
            // k1.PrzesunAlt(-12, 2);
            k1.Promien = -5f;
            k1.Przesun(p);
            // k1.PrzesunAlt(p);
            k1.Promien = 12.3f;
            Console.Write(k1.ToString());
            Console.WriteLine($"Średnica: {k1.Srednica}");
            Console.WriteLine($"Obwód: {k1.Obwod}");
            Console.WriteLine($"Pole: {k1.Pole}");
            Console.Write(k2.ToString());
            Console.WriteLine($"Średnica: {k2.Srednica}");
            Console.WriteLine($"Obwód: {k2.Obwod}");
            Console.WriteLine($"Pole: {k2.Pole}");
        }
    }
}
