using Lexer.Types;
using Parser.Enums;
using Parser.Extensions;
using Parser.Types;

namespace Parser.Functions
{
    internal static class ParserFunctions
    {
        internal static Node ParseNumericLiteral(Parser parser)
        {
            var node = NodeFactory.NumericLiteral(parser.Current.Lexeme!);

            parser.Advance();

            return node;
        }

        internal static Node ParseInnerExpression(Parser parser, Token token, Node left)
        {
            var node = NodeFactory.BinaryOperator(token.GetOperator()) as BinaryOperatorNode;

            node!.Left = left;
            node.Right = ParseExpression(
                parser,
                token.GetOperator().GetPrecedence());

            return node;
        }

        internal static Node ParseExpression(Parser parser, int previousPrecedence)
        {
            var left = ParseNumericLiteral(parser);

            var currentToken = parser.Current;

            var currentOperator = currentToken.GetOperator();
            var currentPrecedence = currentOperator.GetPrecedence();

            while (currentPrecedence != Operator.None.GetPrecedence())
            {
                if (previousPrecedence >= currentPrecedence)
                    break;
                else
                {
                    parser.Advance();

                    left = ParseInnerExpression(parser, currentToken, left);

                    currentOperator = parser.Current.GetOperator();
                    currentPrecedence = currentOperator.GetPrecedence();
                }
            }

            return left;
        }
    }
}
