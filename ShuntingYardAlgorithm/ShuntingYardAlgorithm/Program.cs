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

            }
        }
    }
}