using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VsmServiceController.Models;
using VsmServiceController.Repos;

namespace VsmServiceController.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ServicesSettings _config;
        private readonly IServiceDao _serviceDao;

        public ServiceService(IOptions<ServicesSettings> config, IServiceDao serviceDao)
        {
            _config = config.Value;
            _serviceDao = serviceDao;
        }

        public List<Service> GetServicesStatus()
        {
            List<Service> services = new List<Service>();
            _config.data.ForEach(x =>
            {
                services.Add(new Service { name = x.name, status = CheckStatus(x.url) });
            });
            return services;
        }

        private ServiceStatus CheckStatus(string url)
        {
            var resp = _serviceDao.CheckStatusCode(url);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    return Convert.ToBoolean(resp.Content) == true ?
                        ServiceStatus.Active :
                        ServiceStatus.Alive;
                }
                catch (Exception)
                {
                    return ServiceStatus.Unknown;
                }
            }
            return ServiceStatus.Off;
        }

    }
}
