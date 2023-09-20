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
        public static decimal Evaluate(this Node root) =>
            @interpreter.Evaluate(root);

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
