namespace Contracts
{
    public interface IRepositoryManager
    {
        IOrganizationRepository Organization { get; }
        IUserRepository User { get; }
        ICourseRepository Course { get; }

        void Save();
    }
}