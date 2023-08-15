using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    public class Token
    {
        //
        public enum Type {Number, Operator, EOF }
        public Type TokenType { get; set; }
        public string Value { get; set; }
        public int Precenence { get; set; }
    }
}
