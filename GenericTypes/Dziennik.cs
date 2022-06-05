using SOI;
using System;
using System.Collections.Generic;

namespace GenericTypes
{
    internal class Dziennik<T> where T : IOcenialny
    {
        private List<T> prs;

        public List<T> Prs => prs;

        public Dziennik()
        {
            prs = new List<T>();
        }

        public void Dodaj(T per)
        {
            prs.Add(per);
        }

        public void Usun(T per)
        {
            if (prs.Count != 0)
            {
                prs.Remove(per);
            }
        }

        public void Wyczysc()
        {
            prs.Clear();
        }

        public KeyValuePair<T, float> NajlepszaSrednia()
        {
            if (prs.Count == 0)
                throw new ArgumentNullException(nameof(prs), "Dziennik jest pusty!");
            var pEnum = prs.GetEnumerator();
            pEnum.MoveNext();
            T per = pEnum.Current;
            float max = per.SredniaOcen;
            while (pEnum.MoveNext())
            {
                T tmp = pEnum.Current;
                float sr = tmp.SredniaOcen;
                if (sr > max)
                {
                    max = sr;
                    per = tmp;
                }
            }
            return new KeyValuePair<T, float>(per, max);
        }

        public Dictionary<T, float> WszystkieSrednie()
        {
            if (prs.Count == 0)
                throw new ArgumentNullException(nameof(prs), "Dziennik jest pusty!");
            var d = new Dictionary<T, float>();
            foreach (var el in prs)
            {
                d.Add(el, el.SredniaOcen);
            }
            return d;
        }
    }
}