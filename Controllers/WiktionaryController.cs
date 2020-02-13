using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;


namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WiktionaryController : ControllerBase
    {
        [HttpGet("ipa/{language}/{word}")]
        public IActionResult IPA(string language, string word)
        {

            try
            {
                var url = $"https://{language}.wiktionary.org/wiki/{word.ToLower()}";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var elements = doc.DocumentNode.SelectNodes("//span[@class='IPA']");
                var IPA = elements[0].InnerText.Replace("/", string.Empty).Replace("ˈ", string.Empty);


                return Ok(new
                {
                    IPA = IPA
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside IPA action: {ex.Message}");
            }
        }
    }
}
