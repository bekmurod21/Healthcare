﻿using Newtonsoft.Json;

namespace HealthCare.Service.ApiDtos
{
    public class Info
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
