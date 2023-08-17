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
              private readonly string input;
              private int position;

              public Lexer(string input)
              {
                     this.input = input;
                     position = 0;
              }

              public Token? GetNextToken()
              {
                     if (position >= input.Length)
                     {
                            return new Token { TokenType = Token.Type.EOF };
                     }

                     char currChar = input[position];
                     position++;
                     if (char.IsDigit(currChar))
                     {
                            string num = currChar.ToString();
                            while (position < input.Length && char.IsDigit(input[position]))
                            {
                                   num += input[position];
                            }
                            return new Token { TokenType = Token.Type.Number, Value = num, Precenence = 3 };
                     }
                     else if ("+-*/".Contains(currChar))
                     {
                            Token token = new Token { TokenType = Token.Type.Operator, Value = currChar.ToString() };
                            token.Precenence = currChar == '-' || currChar == '+' ? 2 : currChar == '^' ? 4 : 3;
                            return token;
                     }
                     else if (char.IsWhiteSpace(currChar))
                     {
                            position++;
                            GetNextToken();
                            return null;
                     }
                     else
                     {
                            throw new Exception("Invalid character encountered.");
                     }
              }
       }
}
