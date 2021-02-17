using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace httpexample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            var poster = new HttpGetter(client);
            var dogImage = await poster.Run();
            if (dogImage != null)
            {
                Console.WriteLine(dogImage.Message);
                Console.WriteLine(dogImage.Status);
            }
            else
            {
                Console.WriteLine("Got null");
            }

            var foo = new Foo(1000);
            var th = new Thread(foo.ThreadMethod);
            th.Start();
            th.Join();
            Console.WriteLine("All threads ended");
        }
    }

    public class Foo
    {
        private readonly int _sleeptime;
        
        public Foo(int sleeptime)
        {
            _sleeptime = sleeptime;
        }
        public void ThreadMethod()
        {
            Console.WriteLine("Running in the thread");
            Thread.Sleep(_sleeptime);
        }
    }
}
