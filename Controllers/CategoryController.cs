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
