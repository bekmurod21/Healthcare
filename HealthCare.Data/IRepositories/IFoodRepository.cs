using HealthCare.Domain.Entities;

namespace HealthCare.Data.IRepositories;

public interface IFoodRepository
{
    ValueTask<FoodPower> InsertFoodAsync(FoodPower food);
    ValueTask<FoodPower> UpdateFoodAsync(long id,FoodPower food);
    ValueTask<bool> DeleteFoodAysnyc(long id);
    ValueTask<FoodPower> SelectFoodAsync(Predicate<FoodPower> predicate);
    IQueryable<FoodPower> SelectAllFood();
}
