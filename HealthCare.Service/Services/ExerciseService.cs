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

namespace HealthCare.Service.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExersciseRepository exerciseRepository = new ExerciseRepository();
    private readonly IMapper mapper;
    public ExerciseService(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public async ValueTask<Response<ExerciseDto>> AddExerciseAsync(ExerciseForCreationDto exerciseForCreationDto)
    {
        var exercise = await this.exerciseRepository.SelectExerciseAsync(exercise =>
            exercise.ExerciseName.Equals(exerciseForCreationDto.ExerciseName));

        if (exercise is not null)
            return new Response<ExerciseDto>
            {
                StatusCode = 404,
                Message = "User is already existed",
                Result = (ExerciseDto)exercise
            };
        var mappedExercise = this.mapper.Map<Exercise>(exerciseForCreationDto);
        var addedExercise = await this.exerciseRepository.InsertExerciseAsync(mappedExercise);
        var resultDto = this.mapper.Map<ExerciseDto>(addedExercise);
        return new Response<ExerciseDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteExerciseAsync(long id)
    {
        Exercise exercise = await this.exerciseRepository.SelectExerciseAsync(exercise => exercise.Id.Equals(id));
        if (exercise is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = false
            };

        await this.exerciseRepository.DeleteExerciseAysnyc(id);
        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Result = true
        };
    }

    public async ValueTask<Response<List<ExerciseDto>>> GetAllExerciseAsync(PaginationParams @params, string search = null)
    {
        var exercises = await this.exerciseRepository.SelectAllExercise().ToPagedList(@params).ToListAsync();
        if (exercises.Any())
            return new Response<List<ExerciseDto>>
            {
                StatusCode = 404,
                Message = "Success",
                Result = null
            };

        var result = exercises.Where(user => user.ExerciseName.Contains(search, StringComparison.OrdinalIgnoreCase));
        var mappedExercises = this.mapper.Map<List<ExerciseDto>>(result);
        return new Response<List<ExerciseDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedExercises
        };
    }

    public async ValueTask<Response<ExerciseDto>> GetByExerciseIdAsync(long id)
    {
       Exercise exercise = await this.exerciseRepository.SelectExerciseAsync(user => user.Id.Equals(id));
        if (exercise is null)
            return new Response<ExerciseDto>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = null
            };

        var mappedExercise = this.mapper.Map<ExerciseDto>(exercise);
        return new Response<ExerciseDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedExercise
        };
    }

    public async ValueTask<Response<ExerciseDto>> ModifyExerciseAsync(long id, ExerciseForCreationDto exerciseForCreationDto)
    {
        Exercise exercise = await this.exerciseRepository.SelectExerciseAsync(exercise => exercise.Id.Equals(id));
        if (exercise is null)
            return new Response<ExerciseDto>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = null
            };

        var updatedExercise = await this.exerciseRepository.UpdateExerciseAsync(id, exercise);
        var mappedExercises = this.mapper.Map<ExerciseDto>(updatedExercise);
        return new Response<ExerciseDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedExercises
        };
    }
}
