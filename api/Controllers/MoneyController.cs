using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class MoneyController : ControllerBase
    {

        private readonly ILogger<MoneyController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MoneyController(ILogger<MoneyController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public Models.IMarket Get()
        {
           return _serviceProvider.GetService<Models.IMarket>();
        }
    }
}
