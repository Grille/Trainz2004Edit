namespace TRS2004Edit
{
    public enum TokenType { None, Identifier, Value, String }
    public struct Token
    {
        public int Line;
        public string Value;
        public TokenType Type;
        public Token(int line, TokenType typ, string value)
        {
            Line = line;
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
