using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}