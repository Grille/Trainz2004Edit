using System;
using System.Collections.Generic;
using System.IO;

namespace TRS2004Edit
{
    public class QueryCondition
    {
        public string Name;
        public string Operator;
        public string Value;
        public int Index;
        public QueryCondition(string name, string op, string value)
        {
            Name = name.ToLower(); Operator = op.ToLower(); Value = value.ToLower(); Index = -1;
        }
    }
    public static class Parser
    {
        static public void ParseQuery(string text,out List<string> names, out List<QueryCondition> conditions)
        {

            var tokens = new string[] { };// tokenizeConfig(text);
            names = new List<string>();
            conditions = new List<QueryCondition>();
            var args = text.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var arg in args)
            {
                names.Add(arg.ToLower().Trim(' ', ',', '\n', '\r', '\t'));
            }
            foreach (var condition in conditions)
            {
                var name = condition.Name;
                for (int i = 0;i< names.Count; i++)
                {
                    if (name == names[i])
                    {
                        condition.Index = i;
                    }
                }
            }
            
        }


        static public List<Token> Tokenize(string input)
        {
            
            var tokens = new List<Token>();
            int begin = 0;
            int line = 1;
            var mode = TokenType.None;
            var next = TokenType.Identifier;
            for (int i = 0; i < input.Length; i++)
            {
                int length = i - begin;
                char ch = input[i];
                switch (mode)
                {
                    case TokenType.None:
                        if (ch == '"')
                        {
                            begin = i;
                            mode = TokenType.String;
                        }
                        else if (ch == '\n' || ch == '\r')
                        {
                            next = TokenType.Identifier;
                            line += 1;
                        }
                        else if (ch != ' ' && ch != '\t')
                        {
                            begin = i;
                            mode = next;
                        }
                        break;
                    case TokenType.String:
                        if (ch == '"')
                        {
                            string value = input.Substring(begin, length + 1);
                            tokens.Add(new Token(line, mode, value));
                            next = TokenType.Value;
                            mode = TokenType.None;
                        }
                        break;
                    case TokenType.Value:
                        if (ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r')
                        {
                            string value = input.Substring(begin, length);
                            tokens.Add(new Token(line, mode, value));
                            mode = TokenType.None;
                        }
                        break;
                    case TokenType.Identifier:
                        if (ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r')
                        {
                            string value = input.Substring(begin, length);
                            tokens.Add(new Token(line, mode, value));
                            next = TokenType.Value;
                            mode = TokenType.None;
                        }
                        break;
                }
            }
            return tokens;
        }

        static public TrainzObject Parse(string config)
        {
            var tokens = Tokenize(config);
            int pos = 0;
            return parseObj(tokens, ref pos);
        }

        static private TrainzObject parseObj(List<Token> tokens, ref int pos)
        {
            var obj = new TrainzObject();

            while (pos < tokens.Count - 1)
            {
                var token = tokens[pos++];
                var nexttoken = tokens[pos];
                if (token.Value == "}")
                {
                    break;
                }
                else if (token.Type == TokenType.Identifier && nexttoken.Type != TokenType.Identifier)
                {
                    var key = token.Value;
                    var value = tokens[pos++];
                    try
                    {
                        if (value.Value == "{")
                        {
                            obj.Objects.Add(key, parseObj(tokens, ref pos));
                        }
                        else
                        {
                            obj.Properties.Add(key, getProp(value));
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"{e.Message}\n{token.Line}: {key} = {value.Value}{e.StackTrace}");
                    }
                }
            }
            return obj;
        }

        static private TrainzProperty getProp(Token token)
        {
            string value = token.Value;
            switch (token.Type)
            {
                case TokenType.Value:
                    char ch = value[0];
                    if (ch >= '0' && ch <= '9')
                        return new TrainzProperty(value, PropertyType.Number);
                    if (ch == '<')
                        return new TrainzProperty(value, PropertyType.KUID);
                    break;
                case TokenType.String:
                    return new TrainzProperty(value.Trim('"'), PropertyType.String);      
            }
            return new TrainzProperty(value, PropertyType.None);
        }

    }
}
