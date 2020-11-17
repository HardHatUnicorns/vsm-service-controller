using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VsmServiceController.Models;

namespace VsmServiceController.Repos
{
    public class ServiceDao : IServiceDao
    {
        public IRestResponse CheckStatusCode(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
