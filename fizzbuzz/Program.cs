using System;
using System.Collections.Generic;

namespace fizzbuzz
{
    internal class Program
    {
        private static Dictionary<int, string> replacements = new Dictionary<int, string>()
        {
            {3, "Fizz"},
            {5, "Buzz"},
            {7, "Bang"},
            {11, "Bong"},
            {13, "Fezz"}
        };

        private static void Main(string[] args)
        {
            Console.Out.Write("Please enter the max number: ");
            var max = Convert.ToInt32(Console.ReadLine());

            var output = new List<string>();
            for (var i = 0; i < max; i++)
            {
                output.Clear();

                var curr = i + 1;

                if (curr % 3 == 0)
                    output.Add(replacements[3]);

                if (curr % 5 == 0)
                    output.Add(replacements[5]);

                if (curr % 7 == 0)
                    output.Add(replacements[7]);

                if (curr % 11 == 0)
                {
                    output.Clear();
                    output.Add(replacements[11]);
                }

                if (curr % 13 == 0)
                {
                    var bIdx = output.FindIndex(s => s.StartsWith("B"));

                    if (bIdx >= 0)
                    {
                        output.Insert(bIdx, replacements[13]);
                    }
                    else
                    {
                        output.Add(replacements[13]);
                    }
                }

                if (curr % 17 == 0)
                {
                    output.Reverse();
                }

                if (output.Count == 0)
                    output.Add(curr.ToString());

                Console.Out.WriteLine(string.Join("", output));
            }
        }
    }
}