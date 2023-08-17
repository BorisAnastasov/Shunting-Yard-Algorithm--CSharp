using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    public class Parser
    {
        private Lexer lexer;
        private Token currToken;

        public Parser(string input)
        {
            lexer = new Lexer(input);
            currToken = lexer.GetNextToken();
        }

        public void  Parse() 
        { 
        
        
        }
    }
}
