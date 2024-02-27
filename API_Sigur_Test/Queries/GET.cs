using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API_Sigur_Test.Queries
{
    internal class GET
    {
        public static async Task<string> GetPersonalRestAPI(string id, string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string resultUrl = url + id;
                try
                {
                    HttpResponseMessage responseGetPerson = await client.GetAsync(resultUrl);
                    responseGetPerson.EnsureSuccessStatusCode();
                    string responseBodyGetPerson = await responseGetPerson.Content.ReadAsStringAsync();
                    string username = ExtractClass.ExtractUsernameValue(responseBodyGetPerson);
                    return username;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
            return null;
        }
        public static async Task<string> GetGeneratedToken(string url, string login, string password)
        {
            string jsonQuery = $"{{\"username\": \"{login}\", \"password\": \"{password}\"}}";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(jsonQuery, Encoding.UTF8, "application/json"));
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch { return null; }
                string responseBody = await response.Content.ReadAsStringAsync();
                return ExtractClass.ExtractTokenValue(responseBody);
            }
        }
    }
}
