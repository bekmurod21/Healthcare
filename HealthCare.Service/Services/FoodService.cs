using AutoMapper;
using HealthCare.Data.IRepositories;
using HealthCare.Data.Repositories;
using HealthCare.Domain.Configurations;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;
using HealthCare.Service.Extensions;
using HealthCare.Service.Helpers;
using HealthCare.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Service.Services
{
    public class FoodService : IFoodServise
    {
        private readonly IFoodRepository foodRepository = new FoodRepository();
        private readonly IMapper mapper;
        public FoodService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async ValueTask<Response<FoodDto>> AddFoodAsync(FoodForCreationDto foodForCreationDto)
        {
            var food = await this.foodRepository.SelectFoodAsync(food =>
             food.FoodName.Equals(foodForCreationDto.FoodName) );

            if (food is not null)
                return new Response<FoodDto>
                {
                    StatusCode = 404,
                    Message = "User is already existed",
                    Result = (FoodDto)food
                };
            var mappedFood = this.mapper.Map<FoodPower>(foodForCreationDto);
            var addedFood = await this.foodRepository.InsertFoodAsync(mappedFood);
            var resultDto = this.mapper.Map<FoodDto>(addedFood);
            return new Response<FoodDto>
            {
                StatusCode = 200,
                Message = "Success",
                Result = resultDto
            };
        }

        public async ValueTask<Response<bool>> DeleteFoodAsync(long id)
        {
            FoodPower food = await this.foodRepository.SelectFoodAsync(food => food.Id.Equals(id));
            if (food is null)
                return new Response<bool>
                {
                    StatusCode = 404,
                    Message = "Couldn't find for given ID",
                    Result = false
                };

            await this.foodRepository.DeleteFoodAysnyc(id);
            return new Response<bool>
            {
                StatusCode = 200,
                Message = "Success",
                Result = true
            };
        }

        public async ValueTask<Response<List<FoodDto>>> GetAllFoodAsync(PaginationParams @params, string search = null)
        {
            var foods = await this.foodRepository.SelectAllFood().ToPagedList(@params).ToListAsync();
            if (foods.Any())
                return new Response<List<FoodDto>>
                {
                    StatusCode = 404,
                    Message = "Success",
                    Result = null
                };

            var result = foods.Where(user => user.FoodName.Contains(search, StringComparison.OrdinalIgnoreCase));
            var mappedFoods = this.mapper.Map<List<FoodDto>>(result);
            return new Response<List<FoodDto>>
            {
                StatusCode = 200,
                Message = "Success",
                Result = mappedFoods
            };
        }

        public async ValueTask<Response<FoodDto>> GetByFoodIdAsync(long id)
        {
            FoodPower food = await this.foodRepository.SelectFoodAsync(food => food.Id.Equals(id));
            if (food is null)
                return new Response<FoodDto>
                {
                    StatusCode = 404,
                    Message = "Couldn't find for given ID",
                    Result = null
                };

            var mappedFood = this.mapper.Map<FoodDto>(food);
            return new Response<FoodDto>
            {
                StatusCode = 200,
                Message = "Success",
                Result = mappedFood
            };
        }

        public async ValueTask<Response<FoodDto>> ModifyFoodAsync(long id, FoodForCreationDto foodForCreationDto)
        {
            FoodPower food = await this.foodRepository.SelectFoodAsync(food => food.Id.Equals(id));
            if (food is null)
                return new Response<FoodDto>
                {
                    StatusCode = 404,
                    Message = "Couldn't find for given ID",
                    Result = null
                };

            var updatedFood = await this.foodRepository.UpdateFoodAsync(id,food);
            var mappedFoods = this.mapper.Map<FoodDto>(updatedFood);
            return new Response<FoodDto>
            {
                StatusCode = 200,
                Message = "Success",
                Result = mappedFoods
            };
        }
    }
}
