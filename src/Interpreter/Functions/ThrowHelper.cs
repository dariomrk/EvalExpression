using Interpreter.Exceptions;
using Parser.Enums;
using Parser.Types;

namespace Interpreter.Functions
{
    internal static class ThrowHelper
    {
        public static decimal UnknownNodeType(Node node) =>
            throw new UnknownNodeTypeException($"Unknown {nameof(NodeType)} at {nameof(Node)}: {node}.");
    }
}
