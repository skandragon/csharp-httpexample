using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace httpexample
{
    public class HttpGetter
    {
        private readonly HttpClient _client;
        
        public HttpGetter(HttpClient client)
        {
            _client = client;
        }

        public async Task<DogImage> Run()
        {
            try
            {
                var response = await _client.GetAsync("https://dog.ceo/api/breeds/image/random");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Got an unsuccessful status code");
                    return null;
                }

                if (response.Content.Headers.ContentType?.MediaType == "application/json")
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();

                    try
                    {
                        return await JsonSerializer.DeserializeAsync<DogImage>(contentStream);
                    }
                    catch (JsonException) // Invalid JSON
                    {
                        Console.WriteLine("Invalid JSON.");
                    }

                }
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;
        }
    }
}