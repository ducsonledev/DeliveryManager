using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestClientLieferandoSandboxApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://sandbox-pull-posapi.takeaway.com/";
            var httpClient = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("test-username-123:test-password-123");

            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Add("Apikey", "abc123");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));

            var response = await httpClient.GetAsync("1.0/orders/1234567");
            Console.Write(response);
        }
    }
}
