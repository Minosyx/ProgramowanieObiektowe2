using System;
using System.Linq;
using System.Collections.Generic;

namespace Student
{
    public class Student
    {
        private string imie, nazwisko;
        private uint rokUrodzenia;
        private List<float> tablicaOcen;
        public Student(string imie, string nazwisko, uint rokUrodzenia, float[] tablicaOcen){
            if (DateTime.Now.Year - rokUrodzenia < 18)
                throw new ArgumentOutOfRangeException("rokUrodzenia", rokUrodzenia, $"Osoba {imie} {nazwisko} za młoda na studia!");
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rokUrodzenia = rokUrodzenia;
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
        public void DodajOcene(float ocena, int amount = 1){
            if (ocena > 5 || ocena < 2){
                throw new ArgumentOutOfRangeException("ocena", ocena, "Ocena nie mieści się w określonym przedziale!");
            }
            else if (amount < 1)
                throw new ArgumentOutOfRangeException("amount", amount, "Nieprawidłowa ilość ocen do dodania!");
            else{
                for (int i = 0; i < amount; i++){
                    tablicaOcen.Add(ocena);
                }
            }
        }
        public void DodajOcene(float[] oceny){
            bool error = false;
            foreach (float ocena in oceny)
            {
                if (ocena > 5 || ocena < 2)
                    error = true;
                else
                    tablicaOcen.Add(ocena);
            }
            if (error)
            {
                throw new ArgumentOutOfRangeException("ocena", "Conajmniej jedna z podanych ocen nie mieści się w określonym przedziale!");
            }
        }
        public void UsunOcene(float ocena, int amount = 1){
            if (amount < 1)
                return;
            for(int i = 0; i < amount; i++){
                bool deleted = tablicaOcen.Remove(ocena);
                if (!deleted)
                    break;
            }
        }
        public uint Wiek{
            get {
            uint year = (uint)DateTime.Now.Year;
            return year - rokUrodzenia;
            }
        }
        private string CreateBorder(int width, char sign){
            string text = "";
            return text.PadLeft(width, sign) + '\n';
        }
        private string CreateFiller(int width, char sign){
            string text = "";
            return sign + text.PadLeft(width - 2, ' ') + sign + '\n';
        }
        private string CreateLine(int width, string value, char sign){
            string text = "";
            return sign + value.PadLeft((width - 2) / 2 + value.Length / 2) + text.PadLeft((width - 1) / 2 - value.Length / 2) + sign + '\n';
        }
        public override string ToString(){
            int width = Console.WindowWidth;

            char hframe = '-';
            char vframe = '|';
            string kartaStudenta = "";
            kartaStudenta += CreateBorder(width, hframe);
            kartaStudenta += CreateFiller(width, vframe);
            kartaStudenta += CreateLine(width, "Student", vframe);
            kartaStudenta += CreateFiller(width, vframe);
            kartaStudenta += CreateLine(width, $"{imie} {nazwisko}", vframe);
            kartaStudenta += CreateLine(width, $"Rok urodzenia: {rokUrodzenia}", vframe);
            kartaStudenta += CreateFiller(width, vframe);
            kartaStudenta += CreateBorder(width, hframe);
            string kartaOcen = "";
            char border = '#';
            kartaOcen += CreateBorder(width, border);
            kartaOcen += CreateFiller(width, border);
            kartaOcen += CreateLine(width, "Karta ocen", border);
            kartaOcen += CreateFiller(width, border);
            int i = 0;
            string oceny = "";
            foreach (float ocena in tablicaOcen){
                if (i + 6 > width - 2){
                    kartaOcen += CreateLine(width, oceny, border);
                    kartaOcen += CreateFiller(width, border);
                    oceny = "";
                    i = 0;
                }
                i += 6;
                oceny += $"{ocena.ToString("0.##")}, ";
            }
            if(i != 0){
                kartaOcen += CreateLine(width, oceny, border);
                kartaOcen += CreateFiller(width, border);
                oceny = "";
                i = 0;
            }
            kartaOcen += CreateFiller(width, border);
            kartaOcen += CreateBorder(width, border);
            return kartaStudenta + "\n\n" + kartaOcen;
        }
    }
}