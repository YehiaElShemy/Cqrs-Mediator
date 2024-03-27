using Cqrs_Mediator.Application.Abstractions.HttpClientServices;
using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;
using Cqrs_Mediator_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Cqrs_Mediator.InfraStructure.HttpClientRepositry
{
    public class HttpClientServeices : IHttpClientServeices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientServeices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<TResponse> PostRequest<TResponse>(string url, HttpMethod method=default, TResponse data = default)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("MyHttpClient"))
            {
                var request = new HttpRequestMessage(method, url);
                if (data != null)
                {
                    var json = JsonSerializer.Serialize(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                if (response.Content.Headers.ContentType.MediaType== "application/json")
                {
                    //using var contentStream = await response.Content.ReadAsStreamAsync();
                    return await response.Content.ReadFromJsonAsync<TResponse>();
                    /*  return await DeserializeByteArrayToDtoList<TResponse>(res);
                       // await response.Content.ReadAsByteArrayAsync();
                    */
                }
                else
                {

                    throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }
        }

        public async Task<TResponse> GetRequestById<TResponse>(string url, string id)
        {

            url = url+$"/{id}"; //send id as query pramater
            //url = $"{url}?id={id}"; //send id as query string
            using (HttpClient httpClient = _httpClientFactory.CreateClient("MyHttpClient"))
            {
                var response = await httpClient.GetAsync(url);
                if (response.Content.Headers.ContentType.MediaType== "application/json")
                {
                    return await response.Content.ReadFromJsonAsync<TResponse>();
                }
                else
                {
                    throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<TResponse> DeleteRequestbyid<TResponse>(string url, string id)
        {

            url = url+$"/{id}"; //send id as query pramater
          //  url = $"{url}?id={id}"; //send id as query string
            using (HttpClient httpClient = _httpClientFactory.CreateClient("MyHttpClient"))
            {
                var response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TResponse>();
                }
                else
                {
                    throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
                }
            }
        }


        public async Task<TResponse> DeserializeByteArrayToDtoList<TResponse>(byte[] byteArray)
        {
            // Deserialize the byte array to a list of GetAllProductListDto
            var json = Encoding.UTF8.GetString(byteArray);
            var productList = JsonSerializer.Deserialize<TResponse>(json);

            return productList;


        }
    }
}
