global using Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Services
{
    public class SOSUService<TEntity> : ISOSUService<TEntity> where TEntity : class
    {
        private const string baseUrl = "https://localhost:7020/api";

        public async Task<List<TEntity>> DoHttpGetRequest(string ControllerUrl)
        {
            using var client = new HttpClient();
            var returnResponse = new List<TEntity>();
            string url = $"{baseUrl}/{ControllerUrl}";
            var apiResponse = await client.GetAsync(url);

            returnResponse = JsonConvert.DeserializeObject<List<TEntity>>(await apiResponse.Content.ReadAsStringAsync());
            return returnResponse;
        }

        public async Task<string> DoHttpPostRequest(string controllerUrl, TEntity entityToInsert)
        {
            string returnResponse = $"Something went wrong, trying to insert {nameof(TEntity)}...";
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var serializedEntity = JsonConvert.SerializeObject(entityToInsert);
                var apiResponse = await client.PostAsync(url, new StringContent(serializedEntity, Encoding.UTF8, "application/json"));
                var response = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    returnResponse = "Success!";
                }
            }
            return returnResponse;
        }

        public async Task<string> DoHttpPutRequest(string controllerUrl, TEntity entityToUpdate)
        {
            string returnResponse = $"Something went wrong, trying to update {nameof(TEntity)}...";
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var serializedEntity = JsonConvert.SerializeObject(entityToUpdate);
                var apiResponse = await client.PutAsync(url, new StringContent(serializedEntity, Encoding.UTF8, "application/json"));
                var response = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    returnResponse = "Success!";
                }
            }
            return returnResponse;
        }
    }
}