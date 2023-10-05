using Lexer.Enums;
using Lexer.Types;
using Parser.Enums;
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
                .Select(static token => new Token?(token))
                .GetEnumerator();

            _tokens.MoveNext();
        }

        public Node Parse()
        {
            var expression = Expression();

            if(_tokens.MoveNext())
                ThrowHelper.ExpectedEndOfFile(CurrentToken!.Value.Lexeme);

            return expression;
        }

        private Token ConsumeToken(TokenType expected)
        {
            var token = CurrentToken;

            if (token is null)
                ThrowHelper.UnexpectedEndOfExpression(expected);

            if (token!.Value.Type != expected)
                ThrowHelper.UnexpectedToken(token?.Lexeme, expected);

            _tokens.MoveNext();
            return token!.Value;
        }

        private Node Number()
        {
            var token = ConsumeToken(TokenType.Number);
            return NodeFactory.NumericLiteral(token.Lexeme!);
        }

        private Node ParenthesizedExpression()
        {
            ConsumeToken(TokenType.OpenParenthesis);
            var expression = Expression();
            ConsumeToken(TokenType.CloseParenthesis);

            return expression;
        }

        private Node Unary()
        {
            var token = ConsumeToken(TokenType.Hyphen);
            return NodeFactory.Unary(
                token.Type.ToUnaryNodeType(),
                Factor());
        }

        private Node Primary()
        {
            if(CurrentToken is null)
                ThrowHelper.UnexpectedEndOfExpression(
                    new HashSet<TokenType>
                    {
                        TokenType.Number,
                        TokenType.OpenParenthesis,
                        TokenType.Hyphen,
                    });

            Node node = null!;

            if (CurrentTokenType is TokenType.Number)
                node = Number();

            else if (CurrentTokenType is TokenType.OpenParenthesis)
                node = ParenthesizedExpression();

            else if (CurrentTokenType is TokenType.Hyphen)
                node = Unary();

            if (CurrentToken is null)
                ThrowHelper.UnexpectedEndOfExpression(
                    new HashSet<TokenType>
                    {
                        TokenType.Number,
                        TokenType.OpenParenthesis,
                    });

            while (CurrentTokenType is TokenType.Number or TokenType.OpenParenthesis)
            {
                node = NodeFactory.Binary(
                    NodeType.Multiply,
                    node,
                    Primary());
            }

            return node;
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
                TokenType.Slash,
            });

        private Node Factor() => BinaryExpressionBuilder(
            Primary,
            Factor,
            new HashSet<TokenType>
            {
                TokenType.Caret,
            });

        private Node BinaryExpressionBuilder(
            Func<Node> evaluatesLeft,
            Func<Node> evaluatesRight,
            HashSet<TokenType> expectedTokenTypes)
        {
            var left = evaluatesLeft();

            while (CurrentToken is not null && expectedTokenTypes.Contains(CurrentTokenType))
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