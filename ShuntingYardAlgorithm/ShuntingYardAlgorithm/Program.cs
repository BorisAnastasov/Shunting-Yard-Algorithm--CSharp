using System.Linq;
using System.Collections.Generic;

namespace ShuntingYardAlgorithm
{
       internal class Program
       {

              static void Main(string[] args)
              {
                     //saving the input data as string
                     var input = Console.ReadLine();

                     // creating a queue for the output (it can also be a list etc. - > it doesn't matter)
                     var output = new Queue<string>();

                     // creating a stack for the operators
                     var opStack = new Stack<Token>();

                     // using a parser for taking each element from the input
                     var parser = new Parser(input);

                     // creating a variable for the current element that i am checking
                     var currToken = parser.CurrToken;

                     while (currToken.TokenType != Token.Type.EOF)
                     {
                            if (currToken.TokenType == Token.Type.Number)
                            {
                                   output.Enqueue(currToken.Value);
                            }
                            else if (currToken.TokenType == Token.Type.Operator)
                            {
                                   if (opStack.Count > 0)
                                   {
                                          while (opStack.Peek().TokenType != Token.Type.Parenthesis
                                                && opStack.Peek().Precenence > currToken.Precenence
                                                || (currToken.Precenence == opStack.Peek().Precenence
                                                && opStack.Peek().Associativity == Token.AssociativityType.Left))
                                          {
                                                 output.Enqueue(opStack.Pop().Value);
                                                 if (opStack.Count == 0)
                                                 {
                                                        break;
                                                 }
                                          }
                                   }
                                   opStack.Push(currToken);
                            }
                            else if (currToken.TokenType == Token.Type.Parenthesis && currToken.Parant == Token.ParantType.Right)
                            {
                                   while (opStack.Peek().Value != "(")
                                   {
                                          output.Enqueue(opStack.Pop().Value);
                                          
                                   }
                                   opStack.Pop();
                            }
                            else if (currToken.TokenType == Token.Type.Parenthesis && currToken.Parant == Token.ParantType.Left)
                            {
                                   opStack.Push(currToken);
                            }
                            // check the condition for function => in the next update
                            currToken = parser.Parse();

                     }

                     while (opStack.Count > 0)
                     {
                            output.Enqueue(opStack.Pop().Value);
                     }

                     Console.WriteLine(string.Join(" ",output));
              }
       }
}