namespace PinyinCardApi.Controllers;

using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private RepositoryWrapper _repoWrapper;

    public CategoryController(
    // RepositoryWrapper repoWrapper
    )
    {
        // _repoWrapper = repoWrapper;
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

    [HttpGet("by-parent-category/{categoryId?}")]
    public async Task<IActionResult> GetByCategory(int? categoryId = null)
    {
        try
        {
            var categories = await _repoWrapper.Category.GetAllByParentCategoryAsync(categoryId);
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong inside GetAll action: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
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

            var context = new RepositoryContext();
            await context.AddAsync(category);
            await context.SaveChangesAsync();
            // var repo = new CategoryRepository(context);

            // _repoWrapper.Category.Create(category);
            // await _repoWrapper.SaveAsync();
            // var repoWrapper = new RepositoryWrapper(context);

            // context.Categories.Add(category);
            // repo.Create(category);
            // await repoWrapper.SaveAsync();

            return Created("Created", category);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Category category)
    {
        var categoryEntity = await _repoWrapper.Category.GetByIdAsync(id);

        var properties = category.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (
                property.Name == "Id"
                || property.Name == "CreatedAt"
                || property.Name == "UpdatedAt"
            )
            {
                continue;
            }

            var value = category.GetType().GetProperty(property.Name).GetValue(category);
            categoryEntity
                .GetType()
                .GetProperty(property.Name)
                .SetValue(categoryEntity, value, null);
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
