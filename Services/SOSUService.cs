using Services.Interfaces;
using Newtonsoft.Json;

namespace Services
{
    public class SOSUService<TEntity> : ISOSUService<TEntity> where TEntity : class
    {
        protected static string baseUrl = "";

        public async Task<List<TEntity>> DoHttpGetRequest(string ControllerUrl)
        {
            var returnResponse = new List<TEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{ControllerUrl}";
                var apiResponse = await client.GetAsync(url);

                returnResponse = JsonConvert.DeserializeObject<List<TEntity>>(await apiResponse.Content.ReadAsStringAsync());
                return returnResponse;
            }
        }
    }
}