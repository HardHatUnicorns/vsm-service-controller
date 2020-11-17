using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using VsmServiceController.Models;
using VsmServiceController.Repos;
using VsmServiceController.Services;

namespace VsmServiceController.Controllers
{

    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;


        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("services")]
        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_serviceService.GetServicesStatus());
        }
    }
}
