using System.Linq;
using System.Collections.Generic;

namespace ShuntingYardAlgorithm
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //readind data
            string input = Console.ReadLine();

            List<char> data = input.Split().Select(char.Parse).ToList();

            var output = new Queue<char>();

            var opStack = new Stack<char>();

            while (data.Count > 0)
            {
                if (char.IsDigit(data[0]))
                { 
                    char ch = data[0];
                    data.RemoveAt(0);
                    output.Enqueue(ch);
                }
                else if (data[0] ==     )
                {

                }
            }
        }
    }
}