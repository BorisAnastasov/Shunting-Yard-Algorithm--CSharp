using System.Linq;
using System.Collections.Generic;

namespace ShuntingYardAlgorithm
{
       internal class Program
       {

              static void Main(string[] args)
              {
                     //5 + 4 * 3 * (1 + 2)
                     //readind data
                     var input = Console.ReadLine();

                     var output = new Queue<string>();

                     var opStack = new Stack<Token>();

                     var parser = new Parser(input);

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