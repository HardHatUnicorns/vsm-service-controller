using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VsmServiceController.Models
{
    public class Service
    {
        public string name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ServiceStatus status { get; set; }
    }

    public enum ServiceStatus
    {
        Off,
        Alive,
        Active,
        Unknown
    }
}
