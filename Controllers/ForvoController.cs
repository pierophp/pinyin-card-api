using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForvoController : ControllerBase
    {


        [HttpGet]
        public IActionResult Index()
        {
            // async Task<
            try
            {
                // var client = new HttpClient();
                // var response = await client.GetAsync("https://forvo.com/word/duck/#en_usa");

                return Ok(new
                {
                    welcome = "Welcome to Pinyin Card"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAll action: {ex.Message}");
            }
        }
    }
}
