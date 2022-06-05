using System;
using System.Collections.Generic;

namespace GenericMethods
{
    internal class GenM
    {
        public static IComparable<T> Minimum<T>(IComparable<T> a, IComparable<T> b)
        {
            if (a.CompareTo((T) b) > 0)
                return b;
            else
                return a;
        }

        public static List<T> TurnFill<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            List<T> res = new List<T>();
            bool switcher = false;
            IEnumerator<T> aEnum = a.GetEnumerator();
            IEnumerator<T> bEnum = b.GetEnumerator();
            bool n;
            while ((n = aEnum.MoveNext()) && bEnum.MoveNext())
            {
                if (!switcher)
                {
                    res.Add(aEnum.Current);
                }
                else
                {
                    res.Add(bEnum.Current);
                }
                switcher = !switcher;
            }
            if (n)
            {
                res.Add(aEnum.Current);
            }
            while (aEnum.MoveNext())
            {
                res.Add(aEnum.Current);
            }
            while (bEnum.MoveNext())
            {
                res.Add(bEnum.Current);
            }
            return res;
        }
    }
}