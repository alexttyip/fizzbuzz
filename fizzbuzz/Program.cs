using System;
using System.Collections.Generic;

namespace fizzbuzz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var output = new List<string>();
            for (var i = 0; i < 300; i++)
            {
                output.Clear();

                var curr = i + 1;

                if (curr % 3 == 0)
                    output.Add("Fizz");

                if (curr % 5 == 0)
                    output.Add("Buzz");

                if (curr % 7 == 0)
                    output.Add("Bang");

                if (curr % 11 == 0)
                {
                    output.Clear();
                    output.Add("Bong");
                }

                if (curr % 13 == 0)
                {
                    var bIdx = output.FindIndex(s => s.StartsWith("B"));

                    if (bIdx >= 0)
                    {
                        output.Insert(bIdx, "Fezz");
                    }
                    else
                    {
                        output.Add("Fezz");
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