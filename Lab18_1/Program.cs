using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18_1
{
    class Program
    {
                
        static char GetClosingChar(char c)
        {
            switch (c)
            {
                case '{': return '}';
                case '[': return ']';
                case '(': return ')';                
                default: return ' ';
            }
        }
         
        private static string ClosingBrackets = "}])";
        private static string OpenBrackets = "{[(";
        
        static void CheckBrackets(string s)
        {
            Stack<char> stack = new Stack<char>();
            
            for (int i = 0; i < s.Length; i++)
            {
                char CurrentChar = s[i];
                
                if (OpenBrackets.Contains(CurrentChar))
                    stack.Push(GetClosingChar(CurrentChar));

                if (ClosingBrackets.Contains(CurrentChar))
                {
                    if (stack.Count == 0)
                        throw new FormatException($"Syntax error: found unexpected bracket '{CurrentChar}' on position {i + 1}");
                                        
                    var ExpectedChar = stack.Pop();
                    if (ExpectedChar != CurrentChar)
                        throw new FormatException($"Syntax error: expected closing bracket '{ExpectedChar}' on position {i + 1}, but found '{CurrentChar}'");
                }
            }
                        
            if (stack.Count != 0)
                throw new FormatException($"Syntax error: found at least one unclosed bracket  '{stack.Pop()}' at the end of the string");
        }

        static void Main(string[] args)
        {            
            Console.Write("Please enter text: ");

            try
            {
                CheckBrackets(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Syntax appear valid.");
            Console.ReadKey();

        }
    }
}
