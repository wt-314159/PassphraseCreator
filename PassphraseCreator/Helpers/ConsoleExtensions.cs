using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator
{
    public static class ConsoleExtensions
    {
        public static string? GetInput(Func<string?, bool> predicate, string failureMessage)
        {
            var input = Console.ReadLine();
            while (predicate(input))
            {
                Console.WriteLine(failureMessage);
                input = Console.ReadLine();
            }
            return input;
        }

        public static void LoopProgram(
            Action action,
            string repeatMessage = "To run again, press 'y', to stop press 'n'")
        {
            while (true)
            {
                action();

                Console.WriteLine();
                Console.WriteLine(repeatMessage);

                var input = Console.ReadLine();
                var lower = input?.ToLower();
                if (lower != "y")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
