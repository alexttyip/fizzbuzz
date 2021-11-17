using System;
using System.Collections.Generic;

namespace fizzbuzz
{
    internal class Program
    {
        private static Dictionary<int, string> replacements = new()
        {
            {3, "Fizz"},
            {5, "Buzz"},
            {7, "Bang"},
            {11, "Bong"},
            {13, "Fezz"}
        };

        private static void Main(string[] args)
        {
            // 3, 5, 7
            Dictionary<string, bool> optionalRules = new() {{"3", false}, {"5", false}, {"7", false}};

            foreach (var s in args)
            {
                optionalRules[s] = true;
            }

            Console.Out.Write("Please enter the max number: ");
            var max = Convert.ToInt32(Console.ReadLine());

            var output = new List<string>();
            for (var i = 0; i < max; i++)
            {
                output.Clear();

                var curr = i + 1;

                if (optionalRules[3.ToString()] && curr % 3 == 0)
                    output.Add(replacements[3]);

                if (optionalRules[5.ToString()] && curr % 5 == 0)
                    output.Add(replacements[5]);

                if (optionalRules[7.ToString()] && curr % 7 == 0)
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