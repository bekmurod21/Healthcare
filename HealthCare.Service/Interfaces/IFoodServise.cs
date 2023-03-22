using HealthCare.Domain.Configurations;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;
using HealthCare.Service.Helpers;

namespace HealthCare.Service.Interfaces;

public interface IFoodServise
{
    ValueTask<Response<FoodDto>> AddFoodAsync(FoodForCreationDto foodForCreationDto);
    ValueTask<Response<FoodDto>> ModifyFoodAsync(long id, FoodForCreationDto foodForCreationDto);
    ValueTask<Response<bool>> DeleteFoodAsync(long id);
    ValueTask<Response<FoodDto>> GetByFoodIdAsync(long id);
    ValueTask<Response<List<FoodDto>>> GetAllFoodAsync(PaginationParams @params, string search = null);
}
