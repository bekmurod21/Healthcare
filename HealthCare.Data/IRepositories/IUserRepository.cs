

using HealthCare.Domain.Entities;

namespace HealthCare.Data.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> UpdateUserAsync(long id,User user);
        ValueTask<bool> DeleteUserAysnyc(long id);
        ValueTask<User> SelectUserAsync(Predicate<User> predicate);
        IQueryable<User> SelectAllUsers();
    }
}
