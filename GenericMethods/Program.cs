using System;
using System.Collections.Generic;

namespace GenericMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string a = "Michał";
                string b = "Michalina";

                Console.WriteLine(GenM.Minimum<string>(a, b));
                Console.WriteLine(GenM.Minimum<double>(4.5, 4.49));

                var t1 = new List<int>(new int[] { 1, 3, 5, 7, 9, 11 });
                var t2 = new List<int>(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 });

                var t3 = new List<string>(new string[] { "a", "c", "e", "g" });
                var t4 = new List<string>(new string[] { "b", "d", "f", "h", "i", "j", "k" });

                var r = GenM.TurnFill<int>(t2, t1);
                //var r = GenM.TurnFill<string>(t4, t3);

                foreach (var el in r)
                {
                    Console.Write($"{el} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}