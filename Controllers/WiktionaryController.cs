namespace PinyinCardApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using PinyinCardApi.Core.Wiktionary;

[ApiController]
[Route("[controller]")]
public class WiktionaryController : ControllerBase
{
    [HttpGet("ipa/{language}/{word}")]
    public IActionResult IPA(string language, string word)
    {
        try
        {
            var ipaFinder = new IpaFinder();
            var IPA = ipaFinder.Find(language, word);

            return Ok(new { IPA = IPA });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong inside IPA action: {ex.Message}");
        }
    }
}
