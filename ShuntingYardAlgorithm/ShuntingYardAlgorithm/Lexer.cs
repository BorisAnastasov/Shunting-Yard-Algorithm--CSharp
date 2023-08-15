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
            if(position >= input.Length)
            {
                return new Token {TokenType = Token.Type.EOF };
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
                return new Token { TokenType = Token.Type.Number, Value = num };
            }
            else if ("+-*/".Contains(currChar))
            {
                return new Token { TokenType = Token.Type.Operator, Value = currChar.ToString() };
            }
            else if (char.IsWhiteSpace(currChar))
            {
                if(position-1 < input.Length && position-1 > 0) 
                {
                    if (char.IsWhiteSpace(input[position]))
                    {
                        throw new Exception("Invalid syntaxis.");
                    }
                }
            }
            else
            {
                throw new Exception("Invalid character encountered.");
            }
        }
    }
}
