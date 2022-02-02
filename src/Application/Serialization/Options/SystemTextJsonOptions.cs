using Philcosa.Application.Interfaces.Serialization.Options;
using System.Text.Json;

namespace Philcosa.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}