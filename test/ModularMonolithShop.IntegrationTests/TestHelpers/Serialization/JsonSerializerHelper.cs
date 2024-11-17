using System.Text.Json;

namespace ModularMonolithShop.IntegrationTests.TestHelpers.Serialization
{
    internal static class JsonSerializerHelper
    {
        internal static JsonSerializerOptions DefaultSerializationOptions => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        internal static JsonSerializerOptions DefaultDeserializationOptions => new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
