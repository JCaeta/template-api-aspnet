using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace template_api_aspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
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
    }
}
