using System;

namespace Zespolona
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Zespolona z1 = new Zespolona(6, 4);
                Zespolona z2 = new Zespolona(5, -2);

                // Zespolona z3 = z1 + z2;
                // Zespolona z3 = z1 - z2;
                // Zespolona z3 = z1 * z2;
                // Zespolona z3 = z2 / z1;
                // Zespolona z3 = z1 + 2;
                // Zespolona z3 = z1 - 5;
                // Zespolona z3 = 5 + z1;
                // Zespolona z3 = 7 - z1;
                // Zespolona z3 = z1 * 5;
                // Zespolona z3 = 2 * z1;
                // Zespolona z3 = z1 / 5;
                // Zespolona z3 = 5 / z2;
                Zespolona z3 = new Zespolona(z2);
                // bool test = z3 == z1;
                // bool test = z3 == z2;
                // bool test = z3 != z2;
                // bool test = z3 != z1;
                Zespolona z4 = new Zespolona(5, 0);
                Zespolona z5 = new Zespolona(6, 0);
                // bool test = z5 > z4;
                // bool test = z5 < z4;
                // bool test = z1 < z2;
                // bool test = z1 > z2;
                // Console.WriteLine(test);
                // z3++;
                // z3--;
                // Console.WriteLine((int)z3);
                // Console.WriteLine((double)z3);
                // bool eq = z3.Equals(z1);
                // bool eq = z3.Equals(z2);
                // Console.WriteLine(eq);
                Zespolona zn = new Zespolona();
                // Zespolona z6 = z1 / zn;
                // Zespolona z6 = z1 / 0;
                // Zespolona z6 = 0 / z1;
                // Zespolona z6 = 0 / zn;
                // Zespolona z6 = zn / 0;
                Console.WriteLine(z1.GetHashCode());
                Console.WriteLine(z2.GetHashCode());
                Console.WriteLine(z3.GetHashCode());
                Console.WriteLine(z3.ToString());
                Console.WriteLine(z1.ToString());
                Console.WriteLine(z2.ToString());
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }
}
