using Entities;

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


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}