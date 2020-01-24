using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Threading.Tasks;

namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private RepositoryWrapper _repoWrapper;


        public CategoryController(RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _repoWrapper.Category.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAll action: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _repoWrapper.Category.Create(category);
                await _repoWrapper.SaveAsync();

                return Created("Created", category);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            var categoryEntity = await _repoWrapper.Category.GetByIdAsync(id);

            var properties = category.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "Id" || property.Name == "CreatedAt" || property.Name == "UpdatedAt")
                {
                    continue;
                }

                var value = category.GetType().GetProperty(property.Name).GetValue(category);
                categoryEntity.GetType().GetProperty(property.Name).SetValue(categoryEntity, value, null);
            }

            _repoWrapper.Category.Update(categoryEntity);

            await _repoWrapper.SaveAsync();

            return Ok(categoryEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _repoWrapper.Category.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest();
            }

            _repoWrapper.Category.Delete(category);
            await _repoWrapper.SaveAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _repoWrapper.Category.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
    }
}
