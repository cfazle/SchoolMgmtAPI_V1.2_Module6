using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
   

