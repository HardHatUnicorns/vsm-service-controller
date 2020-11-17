
using RestSharp;
using VsmServiceController.Models;

namespace VsmServiceController.Repos
{
    public interface IServiceDao
    {
        IRestResponse CheckStatusCode(string url);
    }
}