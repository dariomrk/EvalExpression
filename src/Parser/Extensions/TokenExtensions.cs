using Lexer.Enums;
using Lexer.Types;
using Parser.Enums;

namespace Parser.Extensions
{
    internal static class TokenExtensions
    {
        internal static Operator GetOperator(this Token token)
        {
            if (token.Type is TokenType.EndOfFile)
                return Operator.None;

            if (token.Type is not TokenType.Operator)
                throw new ArgumentException($"Cannot provide an {nameof(Operator)} for {nameof(Token)}.Type of {token.Type}.");

            return token.Lexeme switch
            {
                "+" => Operator.Add,
                "-" => Operator.Subtract,
                "*" => Operator.Multiply,
                "/" => Operator.Divide,
                "^" => Operator.Exponentiate,
                "(" => Operator.OpenParenthesis,
                ")" => Operator.CloseParenthesis,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
