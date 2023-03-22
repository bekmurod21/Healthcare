using HealthCare.Data.Context;
using HealthCare.Data.IRepositories;
using HealthCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace HealthCare.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();

    public async ValueTask<User> InsertUserAsync(User user)
    {
        EntityEntry<User> entity = await this.appDbContext.Users.AddAsync(user);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async ValueTask<User> UpdateUserAsync(long id, User user)
    {
        user.Id = id;
        EntityEntry<User> entity = appDbContext.Users.Update(user);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;

        
    }
    public async ValueTask<bool> DeleteUserAysnyc(long id)
    {
        User entity =
            await this.appDbContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.Users.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }
    public async ValueTask<User> SelectUserAsync(Predicate<User> predicate) =>
        await this.appDbContext.Users.FirstOrDefaultAsync(user => predicate(user));

    public IQueryable<User> SelectAllUsers()
    {
        var query = "select * from \"Users\" where \"Firstname\" like '%o%'";
        return this.appDbContext.Users.FromSqlRaw(query);
    }
}
