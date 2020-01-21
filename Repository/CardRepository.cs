using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CardRepository : RepositoryBase<Card>
    {
        public CardRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(e => e.NameEn)
                .ToListAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await FindByCondition(e => e.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
    }
}