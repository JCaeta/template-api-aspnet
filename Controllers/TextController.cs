using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using template_api_aspnet.Models.Requests;
using template_api_aspnet.Models.Responses;
using template_api_aspnet.Tools;

namespace template_api_aspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController
    {
        private readonly ILogger<TextController> _logger;
        private readonly IConfiguration _configuration;

        public TextController(ILogger<TextController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("random", Name = "GetText")]
        public string Get()
        {
            string[] words = { 
                "apple", 
                "banana", 
                "cherry", 
                "orange", 
                "grape", 
                "lemon", 
                "lime", 
                "peach", 
                "pear", 
                "pineapple" 
            };

            Random random = new Random();
            List<string> randomWords = new List<string> { words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)], words[random.Next(words.Length)] };

            string randomWord = words[random.Next(words.Length)];
            return randomWord;
        }

        [HttpDelete("delete", Name = "DeleteText")]
        public async Task<TextResponse> Delete([FromBody] TextRequest request) 
        {
            // This method is only to test token validation
            JwtManager jwtManager = new JwtManager(this._configuration);

            bool isTokenValid = jwtManager.ValidateJwtToken(request.token);

            if (isTokenValid)
            {
                // Token is valid, proceed with the deletion logic
                // ...

                return new TextResponse { message = "Text deleted successfully" };
            }
            else
            {
                // Token is invalid, handle the error
                // ...
                return new TextResponse { message = "Invalid token" };
            }
        }
    }
}
