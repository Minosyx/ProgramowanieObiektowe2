using System.Collections.Generic;

namespace GenericTypes
{
    internal class GenT
    {
        public static Dictionary<char, int> CountChar(string chain)
        {
            var dict = new Dictionary<char, int>();
            foreach (var sign in chain)
            {
                if (dict.ContainsKey(char.ToLower(sign)))
                {
                    dict[sign] += 1;
                }
                else
                    dict.Add(char.ToLower(sign), 1);
            }
            return dict;
        }
    }
}