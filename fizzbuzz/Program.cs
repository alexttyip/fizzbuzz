using System;

namespace fizzbuzz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                var output = "";
                var curr = i + 1;

                if (curr % 3 == 0)
                    output += "Fizz";

                if (curr % 5 == 0)
                    output += "Buzz";

                if (output == "")
                    output += curr.ToString();

                Console.Out.WriteLine(output);
            }
        }
    }
}