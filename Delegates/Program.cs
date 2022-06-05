using System;

namespace Delegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //var tab = new TablicaObliczeniowa<int>(new int[] { 1, 2, 3, 4, 5 });
                var tab = new TablicaObliczeniowa<int>(1, 2, 3, 4, 5);
                //var tab = new TablicaObliczeniowa<int>();
                Console.WriteLine("Suma = " + tab.Oblicz((x, y) => x + y));

                tab.Aplikuj((ref int x) => x *= x, (ref int x) => x -= 1);
                Console.WriteLine(tab);

                TablicaObliczeniowa<int>.AutoOperacja operacja = null;
                operacja = (ref int x) => x *= x;
                operacja += (ref int x) => x -= 1;
                tab.Aplikuj(operacja);
                Console.WriteLine(tab);

                tab.Wykonaj(Array.Sort, Array.Reverse);
                tab.Wykonaj(Console.WriteLine);
                //Console.WriteLine(tab);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}