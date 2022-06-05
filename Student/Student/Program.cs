using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Student patryktajs = new Student("Patryk", "Tajs", 1999, new float[] {5, 5, 4});
                Student jannowak = new Student("Jan", "Nowak", 1998, new float[] {});
                patryktajs.UsunOcene(5);
                patryktajs.DodajOcene(new float[] {3, 2, 5});
                patryktajs.UsunOcene(2);
                patryktajs.DodajOcene(4.75f, 55);
                patryktajs.UsunOcene(4.75f, 54);
                Console.WriteLine(patryktajs.ToString());
                Console.WriteLine(jannowak.ToString());
                Console.WriteLine(patryktajs.Wiek);
                Console.WriteLine(patryktajs.SredniaOcen);
                Console.WriteLine(patryktajs.NajlepszaOcena);
                Console.WriteLine(patryktajs.NajgorszaOcena);
            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }
}
