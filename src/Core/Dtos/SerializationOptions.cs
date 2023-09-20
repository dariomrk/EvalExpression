using System.Text.Json;

namespace Core.Dtos
{
    public sealed class SerializationOptions
    {
        public JsonNamingPolicy? EnumNamingPolicy { get; init; }
        public JsonNamingPolicy? PropertyNamingPolicy { get; init; }
        public bool? WriteIndented { get; init; }
    }
}
