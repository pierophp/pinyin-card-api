namespace PinyinCardApi.Repository;

using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CategoryRepository : RepositoryBase<Category>
{
    public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await FindAll().OrderBy(e => e.NameEn).ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetAllByParentCategoryAsync(int? categoryId)
    {
        return await FindByCondition(e => e.ParentCategoryId.Equals(categoryId))
            .OrderBy(e => e.NameEn)
            .ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
