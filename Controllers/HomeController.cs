using Microsoft.AspNetCore.Mvc;

namespace template_api_aspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHome")]
        public string Get()
        {
            return "This is home";
        }
    }
}
