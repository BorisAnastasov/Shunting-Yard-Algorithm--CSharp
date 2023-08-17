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

                     var output = new Queue<string>();

                     var opStack = new Stack<string>();

                     var parser = new Parser(input);

                     var currToken = parser.CurrToken;

                     while (currToken.TokenType != Token.Type.EOF)
                     {
                            if (currToken.TokenType == Token.Type.Number)
                            {
                                   output.Enqueue(currToken.Value);
                            }
                     }
              }
       }
}