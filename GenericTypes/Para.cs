using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTypes
{
    internal class Para<U, V>
    {
        private U key;
        private V value;

        private Para(U key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public V Value => value;
        public U Key => key;

        public static Para<U, V>[] Paruj(ICollection<U> a, ICollection<V> b)
        {
            if (a.Count() != b.Count())
                throw new ArgumentException("Kolekcje nie są równej długości!");
            var tab = new Para<U, V>[a.Count()];
            IEnumerator<U> aEnum = a.GetEnumerator();
            IEnumerator<V> bEnum = b.GetEnumerator();
            for (int i = 0; aEnum.MoveNext() && bEnum.MoveNext(); i++)
            {
                tab[i] = new Para<U, V>(aEnum.Current, bEnum.Current);
            }
            return tab;
        }
    }
}