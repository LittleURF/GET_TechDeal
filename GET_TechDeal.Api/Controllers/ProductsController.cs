using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GET_TechDeal.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly XkomService _xkomService;

        public ProductsController(ILogger<ProductsController> logger, XkomService xkomService)
        {
            _logger = logger;
            _xkomService = xkomService;
        }

        [HttpGet]
        [Route("current")]
        public ActionResult<Product> GetCurrent()
        {
            return _xkomService.GetCurrentDealProduct();
        }
    }
}
