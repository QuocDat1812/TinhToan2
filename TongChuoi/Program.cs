using System;
using System.Linq.Expressions;
using System.IO;

namespace TongChuoi
{
    class Program
    {
         const string PROMPT = "# ";
            public static void Main()
            {
                Console.WriteLine("Y2 String to Expression Tree");
                Console.WriteLine("https://yinyangit.wordpress.com");

                while (true)
                {
                    Console.Write(PROMPT);
                    string input = Console.ReadLine().Trim();
                    if (input == "")
                    {
                        Console.CursorTop--;
                        continue;
                    }

                    if (string.Compare(input, "exit", true) == 0)
                        break;

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    try
                    {
                        Scanner scanner = new Scanner(input);
                        Parser parser = new Parser(scanner);
                        Expression expr = parser.Parse();
                        Delegate func = Expression.Lambda(expr).Compile();
                        Console.WriteLine("  " + func.DynamicInvoke());

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
    }
}

