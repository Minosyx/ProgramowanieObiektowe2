using System;

namespace SOI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Osoba jankowalski = new Osoba("Jan", "Kowalski", 2003);
                Osoba kubanowak = new Osoba("Jakub", "Nowak", 2002);
                Student johnsmith = new Student("John", "Smith", 1998, new float[] { 5, 4, 3, 4 });
                Student jackmiller = new Student("Jack", "Miller", 2001, new float[] { 3, 4, 2, 4, 3 });

                Osoba[] osobyTab = new Osoba[4];
                osobyTab[0] = jankowalski;
                osobyTab[1] = kubanowak;
                osobyTab[2] = johnsmith;
                osobyTab[3] = jackmiller;

                jackmiller.DodajOcene(new float[] { 2, 4 });
                johnsmith.UsunOcene(4, 5);
                johnsmith.UsunOcene(3);
                johnsmith.UsunOcene(5, 1);
                johnsmith.UsunOcene(4, 3);

                foreach (Osoba p in osobyTab)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine(johnsmith.Imie);
                Console.WriteLine(johnsmith.Nazwisko);
                Console.WriteLine(johnsmith.RokUrodzenia);
                Console.WriteLine(johnsmith.Wiek);

                Console.WriteLine(jackmiller.Imie);
                Console.WriteLine(jackmiller.Nazwisko);
                Console.WriteLine(jackmiller.RokUrodzenia);
                Console.WriteLine(jackmiller.Wiek);

                foreach (Osoba p in osobyTab)
                {
                    if (p is IOcenialny)
                    {
                        Console.WriteLine($"{p.Imie} {p.Nazwisko} jest studentem!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
