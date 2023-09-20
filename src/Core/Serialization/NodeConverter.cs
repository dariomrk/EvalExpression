using Parser.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EvalExpression.Serialization
{
    internal class NodeConverter : JsonConverter<Node>
    {
        public override Node? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            throw new NotImplementedException();

        public override void Write(Utf8JsonWriter writer, Node value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
