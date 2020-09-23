using AppSample.Helpers;
using AppSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppSample.Services
{
    class ApiPeopleDataStore : IDataStore<Person>
    {
        private const string API_BASE_URL = "https://mongooficialv3.azurewebsites.net/";
        private const string API_PESSOAS = "api/pessoas";
        public ApiPeopleDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PESSOAS, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PESSOAS}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Person> GetItemAsync(string id)
        {
            Person retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PESSOAS}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Person>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            List<Person> lista = new List<Person>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PESSOAS);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Person>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PESSOAS}/{item._id}", item);
            return retorno.IsSuccessStatusCode;
        }
    }
}
