using System;

namespace Punkt
{
    class Program
    {
        public static void Main()
        {
            Punkt p = new Punkt();
            Punkt p1 = new Punkt(5.2f, 3.5f);
            p.Przesun(2, 1);
            // p.Odbij();
            Console.WriteLine(p.ToString());
            Console.WriteLine(p1.ToString());
            // p1.Przesun(p);
            p1.Odbij();
            p1.Przesun(-2, 5);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.X);
            Console.WriteLine(p1.Y);
        }
    }
}
