using Newtonsoft.Json;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.Helpers
{
    public static class MobileHelper
    {
        //Definição da conexão e o nome do banco de dados
        private static SQLiteAsyncConnection _connection;
        private static HttpClient _httpClient;
        private static string _apiUrl;
        public const string DbFileName = "sample.db";

        public static SQLiteAsyncConnection GetSqliteConnection()
        {
            if (_connection == null)
            {
                //Cria uma pasta base local para o dispositivo
                var path = new LocalRootFolder();
                //Cria o arquivo
                var arquivo = path.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
                //Abre o BD
                _connection = new SQLiteAsyncConnection(arquivo.Path);
            }
            return _connection;
        }

        private static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> CallApi(HttpMethod method, string api, object objectToSend = null)
        {
            var client = GetHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(method, _apiUrl + api))
            {
                if (objectToSend != null)
                {
                    string contentToSend = JsonConvert.SerializeObject(objectToSend);
                    request.Content = new StringContent(contentToSend, Encoding.UTF8, "application/json");
                }
                return await client.SendAsync(request);
            }
        }

        internal static void SetApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
        }
    }
}
