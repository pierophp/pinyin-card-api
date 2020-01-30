using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PinyinCardApi.Controllers.Cards;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private RepositoryWrapper _repoWrapper;

        private IConfiguration _config;

        public CardController(RepositoryWrapper repoWrapper, IConfiguration config)
        {
            _repoWrapper = repoWrapper;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cards = await _repoWrapper.Card.GetAllAsync();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAll action: {ex.Message}");
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            try
            {
                var cards = await _repoWrapper.Card.GetByCategoryIdAsync(categoryId);
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetByCategory action: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Card card)
        {
            try
            {
                if (card == null)
                {
                    return BadRequest("Object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var image = card.Image;
                card.Image = "";

                _repoWrapper.Card.Create(card);
                await _repoWrapper.SaveAsync();

                var cloudinaryManager = new CloudinaryManager(_config);
                card.Image = await cloudinaryManager.SaveImage(image, card.Id);
                _repoWrapper.Card.Update(card);
                await _repoWrapper.SaveAsync();

                return Created("Created", card);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Card card)
        {
            var cardEntity = await _repoWrapper.Card.GetByIdAsync(id);

            var properties = card.GetType().GetProperties();
            foreach (var property in properties)
            {
                List<string> fields = new List<string>(){
                    "Id",
                    "CreatedAt",
                    "UpdatedAt",
                    "Image",
                };

                if (fields.Contains(property.Name))
                {
                    continue;
                }

                var value = card.GetType().GetProperty(property.Name).GetValue(card);
                cardEntity.GetType().GetProperty(property.Name).SetValue(cardEntity, value, null);
            }

            var cloudinaryManager = new CloudinaryManager(_config);
            cardEntity.Image = await cloudinaryManager.SaveImage(card.Image, cardEntity.Id);

            _repoWrapper.Card.Update(cardEntity);
            await _repoWrapper.SaveAsync();

            return Ok(cardEntity);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _repoWrapper.Card.GetByIdAsync(id);
            if (card == null)
            {
                return BadRequest();
            }

            _repoWrapper.Card.Delete(card);
            await _repoWrapper.SaveAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> Get(int id)
        {
            var card = await _repoWrapper.Card.GetByIdAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }
    }
}
