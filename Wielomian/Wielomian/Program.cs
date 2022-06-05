using System;

namespace Wielomian
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                float[] wsp = new float[] {5.1f, 1, 2, 4};
                float[] wsp1 = new float[] {1, -6, 8};
                Wielomian w = new Wielomian(wsp);
                Wielomian w1 = new Wielomian(wsp1);
                // double[] tab = (double[]) w;
                // float[] tab1 = (float[]) w;
                Wielomian n = new Wielomian();
                // foreach (var i in tab1){
                //     Console.WriteLine($"{i} {i.GetType()}");
                // }
                // Console.WriteLine(w.ToString());
                Console.WriteLine(w1.ToString());
                // n = w + w1;
                // n = w - w1;
                // n = w1 + w;
                // n = w1 - w;
                // Console.WriteLine(n.ToString());
                // Console.WriteLine((string)n);
                // Console.WriteLine(w.Wartosc(5.23f));
                // w[0] = 7;
                // Console.WriteLine(w[0]);
                // Console.WriteLine(w.ToString());
                // Wielomian test = new Wielomian();          
                // Wielomian test2 = new Wielomian(w1);
                // test = (Wielomian)w.Clone();
                // test[0] = 99;
                // test = w1 - w;
                // Console.WriteLine(test.ToString());
                // w[1] = 0;
                // test2[2] = 0;
                // test2[1] = 0;
                // test2[0] = 0;
                // Console.WriteLine(w1.ToString());
                // Console.WriteLine(test2.ToString());
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }

        }
    }
}
