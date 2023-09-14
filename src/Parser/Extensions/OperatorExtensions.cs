using Parser.Enums;
using System.Collections.Frozen;

namespace Parser.Extensions
{
    internal static class OperatorExtensions
    {
        private static readonly FrozenDictionary<Operator, int> _precedenceTable = new Dictionary<Operator, int>
        {
            { Operator.None, 0 },
            { Operator.Add, 1 },
            { Operator.Subtract, 1 },
            { Operator.Multiply, 2 },
            { Operator.Divide, 2 },
            { Operator.Exponentiate, 3 },
            { Operator.OpenParenthesis, 4 },
            { Operator.CloseParenthesis, 4 },
        }.ToFrozenDictionary();

        internal static int GetPrecedence(this Operator @operator)
        {
            return _precedenceTable[@operator];
        }
    }
}
