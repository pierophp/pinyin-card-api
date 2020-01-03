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
            var dbCategory = await _repoWrapper.Category.GetByIdAsync(id);

            dbCategory.NamePt = category.NamePt;
            dbCategory.NameEn = category.NameEn;
            dbCategory.NameChs = category.NameChs;
            dbCategory.NameCht = category.NameCht;

            _repoWrapper.Category.Update(dbCategory);
            await _repoWrapper.SaveAsync();

            return NoContent();
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

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Category>> GetCategory(long id)
        // {
        //     var todoItem = await _repoWrapper.Category.FindAsync(id);

        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     return todoItem;
        // }
    }
}
