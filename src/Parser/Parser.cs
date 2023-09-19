using Lexer.Enums;
using Lexer.Types;
using Parser.Extensions;
using Parser.Functions;
using Parser.Types;

namespace Parser
{
    public sealed class Parser
    {
        private readonly IEnumerator<Token?> _tokens;

        private Token? CurrentToken => _tokens.Current;
        private TokenType CurrentTokenType => _tokens.Current!.Value.Type;

        public Parser(IEnumerable<Token> tokens)
        {
            _tokens = tokens
                .Select(token => new Token?(token))
                .GetEnumerator();

            _ = _tokens.MoveNext();
        }

        public Node Parse() => Expression();

        private Token ConsumeToken(TokenType expected)
        {
            var token = CurrentToken;

            if (token is null)
                ThrowHelper.UnexpectedEndOfExpression(expected);

            if (token!.Value.Type != expected)
                ThrowHelper.UnexpectedToken(token?.Lexeme, expected);

            _ = _tokens.MoveNext();
            return token!.Value;
        }

        private Node ParenthesizedExpression()
        {
            _ = ConsumeToken(TokenType.OpenParenthesis);
            var expression = Expression();
            _ = ConsumeToken(TokenType.CloseParenthesis);

            return expression;
        }

        private Node Unary()
        {
            var token = ConsumeToken(TokenType.Hyphen);
            return NodeFactory.Unary(
                token.Type.ToUnaryNodeType(),
                ParenthesizedExpression());
        }

        private Node Primary()
        {
            if (CurrentToken is null)
                ThrowHelper.UnexpectedEndOfExpression(
                    new HashSet<TokenType>
                    {
                        TokenType.OpenParenthesis,
                        TokenType.Hyphen,
                        TokenType.Number
                    });

            if (CurrentTokenType == TokenType.OpenParenthesis)
                return ParenthesizedExpression();

            if (CurrentTokenType == TokenType.Hyphen)
                return Unary();

            var token = ConsumeToken(TokenType.Number);
            return NodeFactory.NumericLiteral(token.Lexeme!);
        }

        private Node Expression() => BinaryExpressionBuilder(
                Term,
                Term,
                new HashSet<TokenType>
                {
                    TokenType.Plus,
                    TokenType.Hyphen,
                });

        private Node Term() => BinaryExpressionBuilder(
                Factor,
                Factor,
                new HashSet<TokenType>
                {
                    TokenType.Asterisk,
                    TokenType.Slash
                });

        private Node Factor() => BinaryExpressionBuilder(
                Primary,
                Factor,
                new HashSet<TokenType>
                {
                    TokenType.Caret
                });

        private Node BinaryExpressionBuilder(Func<Node> evaluatesLeft, Func<Node> evaluatesRight, HashSet<TokenType> tokenTypes)
        {
            var left = evaluatesLeft();

            while (CurrentToken is not null && tokenTypes.Contains(CurrentTokenType))
            {
                var @operator = ConsumeToken(CurrentTokenType);
                var right = evaluatesRight();

                left = NodeFactory.Binary(
                    @operator.Type.ToBinaryNodeType(),
                    left,
                    right);
            }

            return left;
        }
    }
}