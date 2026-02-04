using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _33_first_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Cherry",
            "Mango",
            "Grapes"
        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public string GetFruitsById(int id)
        {
            return fruits.ElementAt(id);
        }
    }
}
