using System;
using System.Text.Json.Serialization;

namespace httpexample
{
    [Serializable]
    public class DogImage
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}