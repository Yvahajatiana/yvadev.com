namespace Yvadev.Domain.Contracts
{
    using Yvadev.Domain.Entities;

    public interface IUserService
    {
        User GetUser(long id);
    }
}
