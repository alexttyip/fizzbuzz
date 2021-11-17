using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    internal class Program
    {
        private static readonly Dictionary<int, string> Replacements = new()
        {
            {3, "Fizz"},
            {5, "Buzz"},
            {7, "Bang"},
            {11, "Bong"},
            {13, "Fezz"}
        };

        private static void Main(string[] args)
        {
            // Dictionary to store whether the user wants the multiples of these numbers to be replaced.
            Dictionary<int, bool> optionalRules = new() {{3, false}, {5, false}, {7, false}};

            foreach (var s in args)
            {
                try
                {
                    var argInt = int.Parse(s);
                    if (optionalRules.ContainsKey(argInt))
                    {
                        optionalRules[argInt] = true;
                    }
                    else
                    {
                        Console.Out.WriteLine("{0} is not 3, 5, or 7. This is ignored.", argInt);
                    }
                }
                catch (FormatException)
                {
                    Console.Out.WriteLine("{0} is not an int", s);
                    return;
                }
            }

            // Get max number from user.
            Console.Out.Write("Please enter the max number: ");
            var max = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < max; i++)
            {
                // The output list is use to temporarily store the replacements.
                var output = new List<string>();

                var curr = i + 1;

                // Check if the user wants these numbers to be replaced, if so, replace them.
                if (optionalRules[3] && curr % 3 == 0)
                    output.Add(Replacements[3]);

                if (optionalRules[5] && curr % 5 == 0)
                    output.Add(Replacements[5]);

                if (optionalRules[7] && curr % 7 == 0)
                    output.Add(Replacements[7]);

                if (curr % 11 == 0)
                {
                    output.Clear();
                    output.Add(Replacements[11]);
                }

                if (curr % 13 == 0)
                {
                    // Get the index of the first element in output that starts with B
                    var bIdx = output.FindIndex(s => s.StartsWith("B"));

                    if (bIdx >= 0)
                    {
                        // If the element exists, insert the replacement.
                        output.Insert(bIdx, Replacements[13]);
                    }
                    else
                    {
                        // If it doesn't exist, append it.
                        output.Add(Replacements[13]);
                    }
                }

                if (curr % 17 == 0)
                {
                    output.Reverse();
                }

                // If the list is empty, add the number itself.
                if (output.Count == 0)
                    output.Add(curr.ToString());

                Console.Out.WriteLine(string.Join("", output));
            }
        }
    }
}