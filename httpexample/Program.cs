using System.Net.Http;
using System.Threading.Tasks;

namespace httpexample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            var poster = new HttpGetter(client);
            await poster.Run();
        }
    }
}
