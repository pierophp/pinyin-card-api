using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {


        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                var dotnetVersion = Assembly
                    .GetEntryAssembly()?
                    .GetCustomAttribute<TargetFrameworkAttribute>()?
                    .FrameworkName;


                return Ok(new
                {
                    welcome = "Welcome to Pinyin Card",
                    date_time = DateTime.Now,
                    timezone = TimeZoneInfo.Local.DisplayName,
                    os = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                    dotnet_version = dotnetVersion,

                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAll action: {ex.Message}");
            }
        }
    }
}
