using HealthCare.Service.ApiDtos;
using Newtonsoft.Json;

namespace HealthCare.Service.API
{
    public class Users
    {
        [JsonProperty("data")]
        public List<Info> Info { get; set; }
    }
}
