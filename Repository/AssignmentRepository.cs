using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class AssignmentRepository :   RepositoryBase<Assignment>, IAssignmentRepository
    { 
       public AssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
    {
    }
}
}
