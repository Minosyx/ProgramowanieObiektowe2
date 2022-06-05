using System;
using System.Text;

namespace SOI
{
    public class Osoba
    {
        private readonly string imie;
        private readonly string nazwisko;
        private readonly uint rokUrodzenia;
        public Osoba(string imie, string nazwisko, uint rokUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rokUrodzenia = rokUrodzenia;
        }
        public string Imie => imie;
        public string Nazwisko => nazwisko;
        public uint RokUrodzenia => rokUrodzenia;
        public uint Wiek
        {
            get
            {
                uint year = (uint)DateTime.Now.Year;
                return year - rokUrodzenia;
            }
        }
        protected static string CreateBorder(int width, char sign)
        {
            string text = "";
            return new StringBuilder(text.PadLeft(width, sign) + '\n').ToString();
        }
        protected static string CreateFiller(int width, char sign)
        {
            string text = "";
            return new StringBuilder(sign + text.PadLeft(width - 2, ' ') + sign + '\n').ToString();
        }
        protected static string CreateLine(int width, string value, char sign)
        {
            string text = "";
            return new StringBuilder(sign + value.PadLeft((width - 2) / 2 + value.Length / 2) + text.PadLeft((width - 1) / 2 - value.Length / 2) + sign + '\n').ToString();
        }
        protected string PrintPerson(string title)
        {
            int width = Console.WindowWidth;

            char hframe = '-';
            char vframe = '|';
            StringBuilder kartaStudenta = new StringBuilder();
            kartaStudenta.Append(CreateBorder(width, hframe));
            kartaStudenta.Append(CreateFiller(width, vframe));
            kartaStudenta.Append(CreateLine(width, title, vframe));
            kartaStudenta.Append(CreateFiller(width, vframe));
            kartaStudenta.Append(CreateLine(width, $"{imie} {nazwisko}", vframe));
            kartaStudenta.Append(CreateLine(width, $"Rok urodzenia: {rokUrodzenia}", vframe));
            kartaStudenta.Append(CreateFiller(width, vframe));
            kartaStudenta.Append(CreateBorder(width, hframe));
            return kartaStudenta.ToString();
        }
        public override string ToString() => PrintPerson("Osoba");
    }
}
