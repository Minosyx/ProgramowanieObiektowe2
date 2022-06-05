using System;
using System.Linq;
using System.IO;

namespace RegEX
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("RegEX\\cases.txt");
            string[] voivodeships = lines[0].Split('\t').Skip(1).TakeWhile(x => !x.StartsWith("Poland")).ToArray();

            var data = lines.Skip(1).Select(x => x.Split('\t')).Select(x => new 
            { 
                Date = x[0],  
                Data = x.Skip(1).Take(voivodeships.Length).Select(s => string.IsNullOrWhiteSpace(s) ? 0 : int.Parse(s))
            });
            
            var max = data.Select(d => new 
            { 
                Date = d.Date, 
                Max = d.Data.Zip(voivodeships, (x, y) => new Tuple<int, string>(x, y)).OrderByDescending(p => p.Item1).First()
            });
            foreach (var item in max){
                Console.WriteLine($"{item.Date} : {item.Max.Item1} {item.Max.Item2}");
            }
        }
    }
}
