using Parser.Types;

namespace Interpreter.Functions
{
    internal static class InterpreterFunctions
    {
        internal static decimal EvaluateNumericLiteral(Node node) =>
            (node as NumericLiteralNode)!.Value;

        internal static decimal EvaluatePositive(Node node) =>
            Interpreter.Evaluate((node as UnaryNode)!.Next!);

        internal static decimal EvaluateNegative(Node node) =>
            Interpreter.Evaluate((node as UnaryNode)!.Next!) * -1;

        internal static decimal EvaluateAdd(Node node) =>
            Interpreter.Evaluate((node as BinaryNode)!.Left!) + Interpreter.Evaluate((node as BinaryNode)!.Right!);

        internal static decimal EvaluateSubtract(Node node) =>
            Interpreter.Evaluate((node as BinaryNode)!.Left!) - Interpreter.Evaluate((node as BinaryNode)!.Right!);

        internal static decimal EvaluateMultiply(Node node) =>
            Interpreter.Evaluate((node as BinaryNode)!.Left!) * Interpreter.Evaluate((node as BinaryNode)!.Right!);

        internal static decimal EvaluateDivide(Node node) =>
            Interpreter.Evaluate((node as BinaryNode)!.Left!) / Interpreter.Evaluate((node as BinaryNode)!.Right!);

        internal static decimal EvaluateExponentiate(Node node) =>
            (decimal)Math.Pow(
                (double)Interpreter.Evaluate((node as BinaryNode)!.Left!),
                (double)Interpreter.Evaluate((node as BinaryNode)!.Right!));
    }
}
