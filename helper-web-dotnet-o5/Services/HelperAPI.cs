using Newtonsoft.Json;

namespace helper_web_dotnet_o5.Services
{
    public class HelperAPI
    {
        private string _EndPoint;

        public HelperAPI(string EndPoint)
        {
            _EndPoint = EndPoint;
        }

        public async Task<T> MetodoGET<T>(string? Route)
        {
            HttpClient httpClient = new();
            var URI = $"{_EndPoint}?{Route}";
            //var URI = $"{_EndPoint}";

            var response = await httpClient.GetAsync(URI);

            string responseContent = await response.Content.ReadAsStringAsync();

            var retorno = JsonConvert.DeserializeObject<T>(responseContent);

            return retorno;
        }

        public async Task<T> MetodoGETRandom<T>()
        {
            HttpClient httpClient = new();
            var URI = $"{_EndPoint}/GetRandom";

            var response = await httpClient.GetAsync(URI);

            string responseContent = await response.Content.ReadAsStringAsync();

            var retorno = JsonConvert.DeserializeObject<T>(responseContent);

            return retorno;
        }
    }
}
