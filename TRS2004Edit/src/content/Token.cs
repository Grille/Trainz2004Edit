using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS2004Edit
{
    public enum TokenTyp { Identifier, Value,String, Symbol }
    public struct Token
    {
        public string Value;
        public TokenTyp Typ;
        public Token(TokenTyp typ,string value)
        {
            Value = value;
            Typ = typ;
        }


        public static bool operator ==(Token c1, Token c2)
        {
            return c1.Equals(c2);
        }
        public static bool operator !=(Token c1, Token c2)
        {
            return !c1.Equals(c2);
        }
        public override bool Equals(object obj)
        {
            var token = (Token)obj;
            return Value == token.Value && Typ == token.Typ;
        }
    }
}
