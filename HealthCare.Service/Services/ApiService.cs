using HealthCare.Domain.Entities;
using HealthCare.Service.API;
using HealthCare.Service.Helpers;
using HealthCare.Service.Interfaces;
using Newtonsoft.Json;
using System;

namespace HealthCare.Service.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response<List<Users>>> GetAllUsersInformationFromApiAsync()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/users?page=1");


            var json = await response.Content.ReadAsStringAsync();
            json = "[" + json + "]";

            var entities = JsonConvert.DeserializeObject<List<Users>>(json);

            return new Response<List<Users>>()
            {
                StatusCode = 200,
                Message = "Ok",
                Result = entities
            };
        }
    }
}
