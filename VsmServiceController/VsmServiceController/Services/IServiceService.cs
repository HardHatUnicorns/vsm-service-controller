using System.Collections.Generic;
using VsmServiceController.Models;

namespace VsmServiceController.Services
{
    public interface IServiceService
    {
        List<Service> GetServicesStatus();
    }
}