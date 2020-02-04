using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private CategoryRepository _category;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public CategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repositoryContext);
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
                    _card = new CardRepository(_repositoryContext);
                }
                return _card;
            }
        }

        public RepositoryContext GetRepositoryContext()
        {
            return _repositoryContext;
        }

        public void Save()
        {
            AddTimestamps();
            _repositoryContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            AddTimestamps();
            await _repositoryContext.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            foreach (var entry in _repositoryContext.ChangeTracker.Entries())
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