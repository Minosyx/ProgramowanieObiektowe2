using System;
using System.Linq;

namespace Delegates
{
    internal class TablicaObliczeniowa<T>
    {
        private readonly T[] arr;

        public delegate TResult Func<in Type, out TResult>(Type arg);

        public delegate void Action<in Type>(Type obj);

        public delegate void AutoOperacja(ref T x);

        public TablicaObliczeniowa(params T[] parameters)
        {
            arr = new T[parameters.Length];
            parameters.CopyTo(arr, 0);
        }

        public T Oblicz(Func<T, T, T> func)
        {
            return arr.Aggregate<T>(func);
        }

        public void Aplikuj(params AutoOperacja[] func)
        {
            foreach (var f in func)
            {
                for (int i = 0; i < arr.Length; i++)
                    f(ref arr[i]);
            }
        }

        public void Wykonaj(params Action<T[]>[] func)
        {
            foreach (var f in func)
            {
                if (f == Console.WriteLine || f == Console.Write)
                    Console.WriteLine(ToString());
                else
                    f(arr);
            }
        }

        public override string ToString() => "[" + string.Join(", ", arr) + "]";
    }
}