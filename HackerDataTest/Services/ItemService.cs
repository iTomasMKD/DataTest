using HackerDataTest.Models;
using System.Text.Json;

namespace HackerDataTest.Services
{
    public class ItemService : IItemService
    {
        private static readonly HttpClient client;

        static ItemService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://hacker-news.firebaseio.com")
            };
        }

        public async Task<List<Item>> GetHackerData(int id)
        {
            var url = string.Format("/v0/item/{0}", id);
            var result = new List<Item>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<Item>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}
