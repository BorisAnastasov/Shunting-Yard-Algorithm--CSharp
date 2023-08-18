using System.Linq;
using System.Collections.Generic;

namespace ShuntingYardAlgorithm
{
       internal class Program
       {

              static void Main(string[] args)
              {
                     // example: 3 + 4 * 1 + 2

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

                     // going through every token
                     while (currToken.TokenType != Token.Type.EOF)
                     {
                            // if it is a number then add it to the output
                            if (currToken.TokenType == Token.Type.Number)
                            {
                                   output.Enqueue(currToken.Value);
                            }
                            // if is is operator
                            else if (currToken.TokenType == Token.Type.Operator)
                            {
                                   //is there any element in the stack
                                   if (opStack.Any())
                                   {
                                          // poping operator in the output until the meeting of paranthesis,
                                          // the precenence of the current operator is bigger than the top operator in the stack
                                          // or their precenences are equal and the current operator associativity is left
                                          while (opStack.Peek().TokenType != Token.Type.Parenthesis
                                                && opStack.Peek().Precenence > currToken.Precenence
                                                || (currToken.Precenence == opStack.Peek().Precenence
                                                && opStack.Peek().Associativity == Token.AssociativityType.Left))
                                          {
                                                 output.Enqueue(opStack.Pop().Value);
                                                 if (!opStack.Any()) break;
                                          }
                                   }
                                   //always push the current operator in the stack
                                   opStack.Push(currToken);
                            }
                            //if the token is ")" then push every operator in the stack till the "("
                            else if (currToken.TokenType == Token.Type.Parenthesis && currToken.Parant == Token.ParantType.Right)
                            {
                                   while (opStack.Peek().Value != "(")
                                   {
                                          output.Enqueue(opStack.Pop().Value);
                                   }
                                   //lastly pop the "(" because it is still in the stack
                                   opStack.Pop();
                            }
                            //if the token is "(" just push it in the stack
                            else if (currToken.TokenType == Token.Type.Parenthesis && currToken.Parant == Token.ParantType.Left)
                            {
                                   opStack.Push(currToken);
                            }
                            // check the condition for function => try adding this next time

                            //taking the next token
                            currToken = parser.Parse();

                     }

                     //finally poping the operators from the stack and adding them in the output
                     while (opStack.Any())
                     {
                            output.Enqueue(opStack.Pop().Value);
                     }

                     //printing the result
                     Console.WriteLine(string.Join(" ", output));
              }
       }
}