using Interpreter.Functions;
using Parser.Enums;
using Parser.Types;

namespace Interpreter
{
    public static class Interpreter
    {
        public static decimal Evaluate(Node node) => node.NodeType switch
        {
            NodeType.NumericLiteral => InterpreterFunctions.EvaluateNumericLiteral(node),
            NodeType.Positive => InterpreterFunctions.EvaluatePositive(node),
            NodeType.Negative => InterpreterFunctions.EvaluateNegative(node),
            NodeType.Add => InterpreterFunctions.EvaluateAdd(node),
            NodeType.Subtract => InterpreterFunctions.EvaluateSubtract(node),
            NodeType.Multiply => InterpreterFunctions.EvaluateMultiply(node),
            NodeType.Divide => InterpreterFunctions.EvaluateDivide(node),
            NodeType.Exponentiate => InterpreterFunctions.EvaluateExponentiate(node),
            _ => throw new ArgumentException($"Unknown {nameof(NodeType)} at {nameof(Node)}: {node}.")
        };
    }
}