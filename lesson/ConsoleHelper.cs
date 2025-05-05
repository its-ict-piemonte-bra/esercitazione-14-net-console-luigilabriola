using System;

namespace lesson
{
    static class ConsoleHelper
    {
        public static string Ask(string question)
        {
            return Ask(question, null, false);
        }

        public static string Ask(string question, string? errorMessage, bool allowEmpty)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException("Invalid question");
            }

            while (true)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    if (allowEmpty)
                    {
                        return "";
                    }
                    else if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                    }
                }
                else
                {
                    return answer;
                }
            }
        }
    }
}
