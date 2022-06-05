using SOI;
using System;
using System.Collections.Generic;

namespace GenericTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string a = "Konstantynopolitańczykowianeczka";
                var r = GenT.CountChar(a);

                foreach (var el in r)
                {
                    Console.Write($"{el.Key}: {el.Value}, ");
                }

                Console.Write("\n");
                var tab1 = new List<string>(new string[] { "Michał", "Kasia", "Zdzisiek" });
                var tab2 = new List<ulong>(new ulong[] { 21, 22, 53 });
                var tab3 = new List<string>(new string[] { "mężczyzna", "kobieta", "mężczyzna" });

                var res = Para<string, ulong>.Paruj(tab1, tab2);
                var res2 = Para<string, string>.Paruj(tab1, tab3);

                foreach (var el in res)
                {
                    Console.Write($"{el.Key} : {el.Value}, ");
                }

                var johnsmith = new Student("John", "Smith", 2002, new float[] { 2, 5, 3, 4, 2 });
                var oliverjones = new Student("Oliver", "Jones", 1999, new float[] { 5, 3, 3, 5, 2 });
                var jacknewmann = new Student("Jack", "Newmann", 2000, new float[] { 5, 3, 4, 5, 2, 3, 4 });

                var d = new Dziennik<Student>();

                d.Dodaj(johnsmith);
                d.Dodaj(oliverjones);
                d.Dodaj(jacknewmann);
                Console.Write("\n\n");
                Console.WriteLine("Wszystkie osoby w dzienniku:");

                foreach (var p in d.Prs)
                {
                    Console.WriteLine($"{p.Imie} {p.Nazwisko}");
                }

                var resD = d.NajlepszaSrednia();

                Console.WriteLine("\nNajlepsza średnia:");
                Console.WriteLine($"{resD.Key.Imie} {resD.Key.Nazwisko} : {String.Format("{0:#.##}", resD.Value)}");

                var resS = d.WszystkieSrednie();

                Console.WriteLine("\nWszystkie średnie:");
                foreach (var p in resS)
                {
                    Console.WriteLine($"{p.Key.Imie} {p.Key.Nazwisko} : {String.Format("{0:#.##}", p.Value)}");
                }

                d.Usun(oliverjones);
                d.Wyczysc();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}