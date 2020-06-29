using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IOrganizationRepository _organizationRepository;
        private IUserRepository _userRepository;
        private ICourseRepository _courseRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IOrganizationRepository Organization
        {
            get
            {
                if (_organizationRepository == null)
                    _organizationRepository = new OrganizationRepository(_repositoryContext);

                return _organizationRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public ICourseRepository Course
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_repositoryContext);

                return _courseRepository;
            }
        }

      //  ICourseRepository IRepositoryManager.Course => throw new System.NotImplementedException();

        public void Save() => _repositoryContext.SaveChanges();
    }
}
