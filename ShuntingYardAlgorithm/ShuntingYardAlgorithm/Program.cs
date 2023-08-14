using System.Linq;

namespace ShuntingYardAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //readind data
            string input = Console.ReadLine();

            var data = input.Split().ToList<char>();

            var output = new Queue<char>();

            var stack = new Stack<char>();

            while (data.Length > 0)
            {
                if (char.IsDigit(data[0]))
                {
                    output.Enqueue();
                }
                else if ()
                {

                }
            }
        }
    }
}