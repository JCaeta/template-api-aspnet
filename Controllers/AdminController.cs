using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using template_api_aspnet.Models.Requests;
using template_api_aspnet.Models.Responses;
using template_api_aspnet.Services;
using template_api_aspnet.Tools;

namespace template_api_aspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;

        public AdminController(ILogger<AdminController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration; 
        }

        [HttpPost("sign-in", Name = "SignInAdmin")]
        public async Task<AdminResponse> SignIn([FromBody] AdminRequest request)
        {
            AdminResponse response = new AdminResponse();
            AdminServices service = new AdminServices();
            if(await service.SignIn(request.username, request.password))
            {
                var jwtGenerator = new JwtManager(this._configuration);
                string token = jwtGenerator.GenerateJwtToken();
                response.message = "Succesful login";
                response.token = token;

            }else
            {
                response.message = "Incorrect username or password";
                response.token = "";
            }
            return response;
        }
    }
}


