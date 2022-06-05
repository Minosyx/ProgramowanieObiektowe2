using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wyjatki
{
    class MyException : Exception
    {
        public override string Message { get; }
        public int Detail { get; init; }
        public MyException(string msg, int d) => (Message, Detail) = (msg, d);
        public override string ToString() => Message;
    }
    class Punkt
    {
        public int X { get; }
        public int Y { get; }
        public Punkt(int x, int y) => (X, Y) = (x, y);
        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }
    record Osoba
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public Osoba(string name, string surname) => (Name, Surname) = (name, surname);
    }
    interface Kekw
    {
        string Pagman();
    }
    static class Powitanie
    {
        public static string Siema(this int[] p, string name) => name switch
        {
            "Bruce" => "niepocieszajonce",
            _ => "No hej"
        };
    }
    class Bazowa : Kekw
    {
        public virtual string Pagman() => "Co ty dupisz";
    }
    class Pochodna : Bazowa
    {
        public override string Pagman() => "No nie wiem Statiu";
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            //try
            //{
            //    throw new MyException("Wyszło jak wyszło", 2);
            //}
            //catch (MyException e) when (e.Detail == 2)
            //{
            //    Console.WriteLine("Pa tera");
            //    Console.WriteLine(e.ToString());
            //}
            //catch (MyException e)
            //{
            //    Console.WriteLine("No nie");
            //    Console.WriteLine(e.ToString());
            //}

            //(string Imie, string Nazwisko) jb = ("Jan", "Bąk");
            //var jp = (Imie: "Jan Paweł", Przydomek: "Drugi");
            //Console.WriteLine(jp.Przydomek);
            //var (min, max) = jp;
            //Console.WriteLine($"{min} {max}");

            //Punkt p = new(5, 3);
            //var (x, y) = p;
            //Console.WriteLine($"{x}, {y}");

            //bool esc = false;
            //while (esc is false)
            //{
            //    var x = Console.ReadLine();
            //    if (x == string.Empty)
            //        esc = true;
            //    if (x != string.Empty)
            //        Console.WriteLine($"Odpowiedź: {x}");
            //}
            //var x = 5;
            //if (x is int count)
            //{
            //    Console.WriteLine(count);
            //}
            //int[] tab = new int[] { 1, 2, 3, 4, 5 }; // funkcje moga zwracac referencje
            //ref int x = ref ROddaj(tab);
            //x = 3;
            //foreach (var el in tab)
            //{
            //    Console.WriteLine(el);
            //}

            //Console.WriteLine(Print()); // mozna tworzyc funkcje lokalne
            //int b = 0b101_101;
            //int c = 24_147_352;
            //Console.WriteLine(c);
            //int count = 5;
            //int label = 2;
            //var p = (count, label);
            //Console.WriteLine($"{p.label}, {p.count}");

            //            string a = $@"Kappa
            //Pride";
            //            Console.WriteLine(a);

            //int[] t = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //IAsyncEnumerable<int> tab = t as IAsyncEnumerable<int>;
            //await foreach (var item in tab.)
            //{

            //}
            //Osoba p = new Osoba("Maciek", "Szczęsny");
            //Osoba p2 = p with { Name = "Michaś" };
            ////Osoba p3 = p with { DataUrodzenia = new DateTime(2000, 1, 1) };
            //Console.WriteLine(p2);

            //Point p = new(8, 4);
            //Point p1 = Transform(p);
            //Console.WriteLine(p1);

            //var server = "localhost"; // klient tcp
            //TcpClient client = new TcpClient(server, 80);
            //string message = "GET / HTTP/1.1\nHost: " + server + "\n\n";
            //byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            //NetworkStream stream = client.GetStream();
            //stream.Write(data, 0, data.Length);
            //data = new byte[256];
            //string odp = string.Empty;
            //int bytes;
            //do
            //    {
            //    bytes = stream.Read(data, 0, data.Length);
            //    odp += System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            //    }
            //while (bytes > 0) ;
            //Console.WriteLine("Pobrane: {0}", odp);
            //stream.Close();
            //client.Close();

            //var server = new TcpListener(IPAddress.Any, 12345);
            //server.Start();
            //byte[] bytes = new byte[256];
            //while (true)
            //{
            //    TcpClient client = server.AcceptTcpClient();
            //    string data = null;
            //    int len, nl;
            //    NetworkStream stream = client.GetStream();
            //    while ((len = stream.Read(bytes, 0, bytes.Length)) > 0)
            //    {
            //        data += Encoding.ASCII.GetString(bytes, 0, len);
            //        while ((nl = data.IndexOf('\n')) != -1) {
            //            string line = data.Substring(0, nl + 1);
            //            data = data.Substring(nl + 1);
            //            byte[] msg = Encoding.ASCII.GetBytes(PingPong(line));
            //            stream.Write(msg, 0, msg.Length);
            //            }
            //        }
            //    client.Close();
            //}

            //int[][] matrix = new int[5][];
            //for (int i = 0; i < 5; i++)
            //{
            //    matrix[i] = new int[7];
            //}
            //matrix[4][5] = 5;
            //Console.WriteLine(matrix.Length);
            //Console.WriteLine(matrix);

            //Bazowa b = new();
            //Pochodna p = new();

            //Console.WriteLine((p as Kekw).Pagman());
            //unsafe
            //{
            //    int[,] matrix = new int[5, 3];
            //    matrix[1, 1] = 7;
            //    fixed (int* ptr = matrix)
            //    {
            //        int* it = ptr;
            //        for (int i = 0; i < matrix.Length; i++)
            //        {
            //            Console.WriteLine(*it++);
            //        }
            //    }
            //}
            //Console.WriteLine(Math.Abs(-56));
            //int[] tablicka = null;
            //Console.WriteLine(tablicka.Siema("Patryk"));
            Console.WriteLine(0b101);
        }
        public record Point(int X, int Y);
        static Point Transform(Point point) => point switch
        {
            var(x, y) when x < y => new Point(-x, y),
            var(x, y) when x > y => new Point(x, -y),
            var(x, y) => new Point(x, y)
        };
        public static string Print()
        {
            string Okayeg()
            {
                return "Popoga";
            }
            return "Monke " + Okayeg();
        }
        public static int Oddaj(int[] tab)
        {
            return tab[0];
        }
        public static ref int ROddaj(int[] tab)
        {
            return ref tab[0];
        }
    }
}
