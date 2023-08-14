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
        }
    }
}
