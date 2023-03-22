using HealthCare.Data.Context;
using HealthCare.Data.IRepositories;
using HealthCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HealthCare.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteFoodAysnyc(long id)
    {
        FoodPower entity =
            await this.appDbContext.FoodPower.FirstOrDefaultAsync(food => food.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.FoodPower.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<FoodPower> InsertFoodAsync(FoodPower food)
    {
        EntityEntry<FoodPower> entity = await this.appDbContext.FoodPower.AddAsync(food);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public IQueryable<FoodPower> SelectAllFood()
    {
        var query = "select * from \"FoodPower\" where \"FoodName\" like '%o%'";
        return this.appDbContext.FoodPower.FromSqlRaw(query);
    }

    public async ValueTask<FoodPower> SelectFoodAsync(Predicate<FoodPower> predicate)
    {
       return await this.appDbContext.FoodPower.FirstOrDefaultAsync(user => predicate(user));
    }

    public async ValueTask<FoodPower> UpdateFoodAsync(long id,FoodPower food)
    {
        food.Id = id;
        EntityEntry<FoodPower> entity = this.appDbContext.FoodPower.Update(food);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }
}
