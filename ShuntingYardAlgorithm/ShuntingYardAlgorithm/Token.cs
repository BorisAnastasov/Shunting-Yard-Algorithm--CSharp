using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
       public class Token
       {
              public enum AssociativityType { Left, Right }
              public enum ParantType { Left, Right }
              public enum Type { Number, Operator, Parenthesis, EOF }


              public Type TokenType { get; set; }
              public string Value { get; set; }
              public int Precenence { get; set; }
              public AssociativityType Associativity { get; set; }
              public ParantType Parant { get; set; }
       }
}
