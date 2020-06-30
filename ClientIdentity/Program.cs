using System;
using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ClientIdentity
{
    class Program
    {
        private static async Task Main()
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "whether.client",
                ClientSecret = "secret1",
                Scope = "api2"

            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:44355/weatherforecast");
            Console.WriteLine(response.StatusCode);


            var tokenResponseLectural = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            if (tokenResponseLectural.IsError)
            {
                Console.WriteLine(tokenResponseLectural.Error);
                return;
            }


            Console.WriteLine(tokenResponseLectural.Json);

            var apiClientLec = new HttpClient();
            apiClientLec.SetBearerToken(tokenResponseLectural.AccessToken);

            var responseLect = await apiClient.GetAsync("https://localhost:44351/api/Lecturals");
            if (!responseLect.IsSuccessStatusCode)
            { 
                Console.WriteLine(responseLect.StatusCode);
            }
            else
            {
                var content = await responseLect.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
