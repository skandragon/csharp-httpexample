using System;
using System.Net.Http;
using System.Net.Http.Json;
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
        
        public async Task Run()
        {
            try
            {
                var dogImage = await _client.GetFromJsonAsync<DogImage>("https://dog.ceo/api/breeds/image/random");
                if (dogImage != null)
                {
                    Console.WriteLine(dogImage.Message);
                    Console.WriteLine(dogImage.Status);
                }
                else
                {
                    Console.WriteLine("Got null");
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
        }
    }
}