using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.IntegrationTests
{
    public static class Extensions
    {
        public static async Task<T> GetResponseContent<T>(this HttpResponseMessage response)
        {
            var responseContentAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContentAsString);
        }

        public static StringContent GetAsSerializedString(this object value)
        {
            return new StringContent(
                JsonConvert.SerializeObject(value),
                System.Text.Encoding.UTF8, "application/json");
        }
    }
}