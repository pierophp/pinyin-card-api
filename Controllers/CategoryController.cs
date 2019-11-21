using Contracts;
using System;
using Microsoft.AspNetCore.Mvc;

namespace PinyinCardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public CategoryController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IActionResult GetAllOwners()
        {
            try
            {
                var categories = _repoWrapper.Category.FindAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAllOwners action: {ex.Message}");
            }
        }
    }
}
