using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOI
{
    public class Student : Osoba, IOcenialny
    {
        private readonly List<float> tablicaOcen;

        public Student(string imie, string nazwisko, uint rokUrodzenia, float[] tablicaOcen) : base(imie, nazwisko, rokUrodzenia)
        {
            if (DateTime.Now.Year - rokUrodzenia < 18)
                throw new ArgumentOutOfRangeException(nameof(rokUrodzenia), rokUrodzenia, $"Osoba {imie} {nazwisko} za młoda na studia!");
            if (tablicaOcen.Length == 0)
                this.tablicaOcen = new List<float>();
            else if (tablicaOcen.Min() < 2 || tablicaOcen.Max() > 5)
                throw new ArgumentOutOfRangeException("ocena", "Conajmniej jedna z podanych ocen nie mieści się w określonym przedziale!");
            else
                this.tablicaOcen = new List<float>(tablicaOcen);
        }
        public float SredniaOcen => tablicaOcen.Average();
        public float NajlepszaOcena => tablicaOcen.Max();
        public float NajgorszaOcena => tablicaOcen.Min();
        public void DodajOcene(float ocena, int amount = 1)
        {
            if (ocena > 5 || ocena < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(ocena), ocena, "Ocena nie mieści się w określonym przedziale!");
            }
            else if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Nieprawidłowa ilość ocen do dodania!");
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    tablicaOcen.Add(ocena);
                }
            }
        }
        public void DodajOcene(float[] oceny)
        {
            if (oceny.Length == 0)
                return;
            else if (oceny.Max() > 5 || oceny.Min() < 2)
                throw new ArgumentOutOfRangeException("ocena", "Conajmniej jedna z podanych ocen nie mieści się w określonym przedziale!");
            else
                tablicaOcen.AddRange(oceny);
        }
        public void UsunOcene(float ocena, int amount = 1)
        {
            if (amount < 1)
                return;
            for (int i = 0; i < amount; i++)
            {
                bool deleted = tablicaOcen.Remove(ocena);
                if (!deleted)
                    break;
            }
        }
        private string PrintGradecard()
        {
            int width = Console.WindowWidth;

            StringBuilder kartaOcen = new StringBuilder();
            char border = '#';
            kartaOcen.Append(CreateBorder(width, border));
            kartaOcen.Append(CreateFiller(width, border));
            kartaOcen.Append(CreateLine(width, "Karta ocen", border));
            kartaOcen.Append(CreateFiller(width, border));
            int i = 0;
            StringBuilder oceny = new StringBuilder();
            foreach (float ocena in tablicaOcen)
            {
                if (i + 6 > width - 2)
                {
                    kartaOcen.Append(CreateLine(width, oceny.ToString(), border));
                    kartaOcen.Append(CreateFiller(width, border));
                    oceny.Clear();
                    i = 0;
                }
                i += 6;
                oceny.Append($"{ocena:0.##}, ");
            }
            if (i != 0)
            {
                kartaOcen.Append(CreateLine(width, oceny.ToString(), border));
                kartaOcen.Append(CreateFiller(width, border));
                oceny.Clear();
            }
            kartaOcen.Append(CreateFiller(width, border));
            kartaOcen.Append(CreateBorder(width, border));
            return kartaOcen.ToString();
        }
        public override string ToString() => new StringBuilder(PrintPerson("Student") + "\n\n" + PrintGradecard()).ToString();
    }
}
