using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }
    }
}
   
