using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private CategoryRepository _category;
        public CategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }

        private CardRepository _card;
        public CardRepository Card
        {
            get
            {
                if (_card == null)
                {
                    _card = new CardRepository(_repoContext);
                }
                return _card;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            AddTimestamps();
            _repoContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            AddTimestamps();
            await _repoContext.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            foreach (var entry in _repoContext.ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity == false)
                {
                    continue;
                }

                if (entry.State != EntityState.Added && entry.State != EntityState.Modified)
                {
                    continue;
                }


                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.Now;
                }

                ((BaseEntity)entry.Entity).UpdatedAt = DateTime.Now;
            }
        }
    }
}