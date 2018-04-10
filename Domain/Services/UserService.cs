namespace Yvadev.Domain.Services
{
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;

    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> asyncRepository;
        private readonly IRepository<User> repository;

        public UserService(IAsyncRepository<User> asyncRepository, IRepository<User> repository)
        {
            this.asyncRepository = asyncRepository;
            this.repository = repository;
        }
        public User GetUser(long id)
        {
            return repository.Get(id);
        }
    }
}
