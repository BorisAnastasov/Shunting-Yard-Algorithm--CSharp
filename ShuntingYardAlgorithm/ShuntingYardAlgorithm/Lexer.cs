using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
       public class Lexer
       {
              private string input;
              private int position;

              public Lexer(string input)
              {
                     this.input = input;
                     position = 0;
              }

              public Token GetNextToken()
              {
                     if (position >= input.Length)
                     {
                            return new Token { TokenType = Token.Type.EOF };
                     }
                     char currChar = input[position];
                     position++;
                     currChar = currChar == ' ' ? input[position++] : input[position-1];
                     if (char.IsDigit(currChar))
                     {
                            string num = currChar.ToString();
                            while (position < input.Length && char.IsDigit(input[position]))
                            {
                                   num += input[position];
                                   position++;
                            }
                            return new Token { TokenType = Token.Type.Number, Value = num };
                     }
                     else if ("+-*/^".Contains(currChar))
                     {
                            Token token = new Token { TokenType = Token.Type.Operator, Value = currChar.ToString() };
                            token.Precenence = currChar == '-' || currChar == '+' ? 2 : currChar == '^' ? 4 : 3;
                            token.Associativity = currChar == '^' ? Token.AssociativityType.Right : Token.AssociativityType.Left;
                            return token;
                     }
                     else if ("()".Contains(currChar))
                     {

                            var token = new Token { TokenType = Token.Type.Parenthesis, Value = currChar.ToString() };
                            token.Parant = currChar == '(' ? Token.ParantType.Left : Token.ParantType.Right;
                            return token;
                     }
                     else
                     {
                            throw new Exception("Invalid character encountered.");
                     }
              }
       }
}
