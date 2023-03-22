using AutoMapper;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;

namespace HealthCare.Service.Mapper;

public class MappingProfile: Profile 
{
    public MappingProfile()
    {
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserDto,User>().ReverseMap();
        CreateMap<FoodDto,FoodPower>().ReverseMap();
        CreateMap<FoodForCreationDto,FoodPower>().ReverseMap();
        CreateMap<ExerciseDto, Exercise>().ReverseMap();
        CreateMap<ExerciseForCreationDto, Exercise>().ReverseMap();
    }

}
