using Inbound.Models;
using Inbound.Models.Dto;
using Inbound.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inbound.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public  IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpCLient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("OrderApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data!=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8,"application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch(apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Post;
                        break;
                    default:
                    
                        message.Method = HttpMethod.Get;
                        break;

                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }catch(Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}
