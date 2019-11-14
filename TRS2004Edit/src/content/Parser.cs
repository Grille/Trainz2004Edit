using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TRS2004Edit
{
    public class Parser
    {
        int index = 0;
        string text;
        List<Token> tokens;
        public Parser()
        {

        }
        public List<Token> Tokenize(string data)
        {
            int count = 0;
            var tokens = new List<Token>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '\n')
                    count = 0;
                if (data[i] == '"')
                {
                    i += 1;
                    int start = i, end = 0;
                    while (data[i] != '"')
                    {
                        end = i++;
                    }
                    if (end != 0)
                        tokens.Add(new Token(TokenType.String, "" + data.Substring(start, end - start + 1)));
                    else
                        tokens.Add(new Token(TokenType.String, ""));
                }
                else if (data[i] == '{' || data[i] == '}')
                {
                    tokens.Add(new Token(TokenType.Symbol, "" + data[i]));
                }
                else if (data[i] == '\n' || data[i] == ' ' || data[i] == '\r' || data[i] == ';' || data[i] == ';' || data[i] == '\t')
                {
                }
                else
                {
                    int start = i, end = 0;
                    while ((data[i] >= 65 && data[i] <= 90) || (data[i] >= 97 && data[i] <= 122) || (data[i] >= 48 && data[i] <= 57) || data[i] == 95 || data[i] == 46 || data[i] == '<' || data[i] == '>' || data[i] == ':' || data[i] == '-' || data[i] == ',')
                    {
                        end = i++;
                    }
                    i -= 1;
                    if (end != 0)
                    {
                        if (count == 0)
                        {
                            tokens.Add(new Token(TokenType.Identifier, "" + data.Substring(start, end - start + 1).ToLower()));
                            count = 1;
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.Value, "" + data.Substring(start, end - start + 1)));
                            count = 0;
                        }
                    }
                    else
                    {
                        throw new Exception("Unexpected symbol \"" + data[i + 1] + "\"");
                    }

                }
            }

            /*
            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Identifier:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(token.Value + " ");
                        break;
                    case TokenType.Value:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(token.Value);
                        break;
                    case TokenType.String:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(token.Value);
                        break;
                    case TokenType.Symbol:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(token.Value);
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            */

            return tokens;
        }
        public TrainzObject ParseFile(string path)
        {
            return Parse(File.ReadAllText(path));
        }
        public TrainzObject Parse(string text)
        {
            int index = 0;
            var tokens = Tokenize(text);
            return parse(tokens, ref index);
        }
        private TrainzObject parse(List<Token> tokens, ref int i, string name = null)
        {
            var obj = new TrainzObject(name);
            while (i < tokens.Count - 1)
            {
                var token0 = tokens[i];
                var token1 = tokens[i + 1];

                if (token0.Type == TokenType.Symbol && token0.Value == "}")
                {
                    i += 1;
                    break;
                }
                else if (token0.Type == TokenType.Identifier && token1.Type == TokenType.Symbol && token1.Value == "{")
                {
                    i += 2;
                    var value = parse(tokens, ref i, token0.Value);
                    obj.Add(token0.Value, value);
                }
                else if (token0.Type == TokenType.Identifier && token1.Type != TokenType.Symbol)
                {
                    i += 2;
                    obj.Set(token0.Value, token1.Value, PropertyType.Number);
                }
                else
                {
                    i += 1;
                }
            }
            return obj;
        }
    }
}
