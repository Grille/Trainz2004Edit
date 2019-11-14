namespace TRS2004Edit
{
    public enum TokenType { Identifier, Value, String, Symbol }
    public struct Token
    {
        public string Value;
        public TokenType Type;
        public Token(TokenType typ, string value)
        {
            Value = value;
            Type = typ;
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
            return Value == token.Value && Type == token.Type;
        }
    }
}
