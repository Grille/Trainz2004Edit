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
        string text;
        List<Token> tokens;
        public Parser()
        {

        }
        public void Tokenize(string data)
        {
            int count = 0;
            tokens = new List<Token>();
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
                        tokens.Add(new Token(TokenTyp.String, "" + data.Substring(start, end - start + 1)));
                    else
                        tokens.Add(new Token(TokenTyp.String, ""));
                }
                else if (data[i] == '{' || data[i] == '}')
                {
                    tokens.Add(new Token(TokenTyp.Symbol, "" + data[i]));
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
                            tokens.Add(new Token(TokenTyp.Identifier, "" + data.Substring(start, end - start + 1)));
                            count = 1;
                        }
                        else
                        {
                            tokens.Add(new Token(TokenTyp.Value, "" + data.Substring(start, end - start + 1)));
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
                switch (token.Typ)
                {
                    case TokenTyp.Identifier:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(token.Value + " ");
                        break;
                    case TokenTyp.Value:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(token.Value);
                        break;
                    case TokenTyp.String:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(token.Value);
                        break;
                    case TokenTyp.Symbol:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(token.Value);
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            */
        }
        public TrainzObject ParseFile(string path)
        {
            return Parse(File.ReadAllText(path));
        }
        public TrainzObject Parse(string text)
        {
            Tokenize(text);

            var result = new TrainzObject();

            for (int i = 0; i < tokens.Count; i++)
            {

            }

            return result;
        }
    }
}
