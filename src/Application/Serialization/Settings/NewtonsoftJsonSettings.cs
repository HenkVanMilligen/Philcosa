
using TestApi2.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace TestApi2.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}