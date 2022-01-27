using System.Text.Json;
using TestApi2.Application.Interfaces.Serialization.Options;

namespace TestApi2.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}