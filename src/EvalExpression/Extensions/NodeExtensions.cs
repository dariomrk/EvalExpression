using EvalExpression.Dtos;
using EvalExpression.Serialization;
using Parser.Types;
using System.Text.Json;
using System.Text.Json.Serialization;
using @interpreter = Interpreter.Interpreter;

namespace EvalExpression.Extensions
{
    public static class NodeExtensions
    {
        /// <summary>
        /// Evaluates the provided AST.
        /// </summary>
        /// <param name="root">Node to be evaluated</param>
        /// <returns>The result of the AST evaluation</returns>
        public static decimal Evaluate(this Node root) =>
            @interpreter.Evaluate(root);

        /// <summary>
        /// Converts the AST to a JSON representation.
        /// </summary>
        /// <param name="root">Node to be evaluated</param>
        /// <param name="options">JSON serialization options</param>
        /// <returns>A JSON representation of the AST</returns>
        public static string ToJsonString(this Node root, SerializationOptions? options = default)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters =
                { 
                    new NodeConverter(),
                    new JsonStringEnumConverter(options?.EnumNamingPolicy ?? JsonNamingPolicy.SnakeCaseUpper),
                },
                AllowTrailingCommas = false,
                WriteIndented = options?.WriteIndented ?? true,
                PropertyNamingPolicy = options?.PropertyNamingPolicy ?? JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Serialize(root, jsonSerializerOptions);
        }
    }
}
