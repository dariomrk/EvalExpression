using Lexer.Types;

namespace Lexer.Interfaces
{
    public interface ILexer
    {
        public IEnumerable<Token> Tokenize(string expressionString);
    }
}
