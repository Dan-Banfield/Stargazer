using System.Text.Json;

namespace Stargazer.API
{
    public static class APIManager
    {
        private const string API_KEY = "fdcw4ApjteqfsfJ4nGkkDyuWA4JlfgQzACtfpbhI";
        private const string API_ENDPOINT = "https://api.nasa.gov/planetary/apod?api_key=";

        public static async Task<APIResposne> GetAPIResponseAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(API_ENDPOINT + API_KEY))
                {
                    Stream jsonStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<APIResposne>(jsonStream);
                }
            }
        }
    }
}