using HealthCare.Domain.Configurations;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;
using HealthCare.Service.Helpers;

namespace HealthCare.Service.Interfaces
{
    public interface IExerciseService
    {
        ValueTask<Response<ExerciseDto>> AddExerciseAsync(ExerciseForCreationDto exerciseForCreationDto);
        ValueTask<Response<ExerciseDto>> ModifyExerciseAsync(long id, ExerciseForCreationDto exerciseForCreationDto);
        ValueTask<Response<bool>> DeleteExerciseAsync(long id);
        ValueTask<Response<ExerciseDto>> GetByExerciseIdAsync(long id);
        ValueTask<Response<List<ExerciseDto>>> GetAllExerciseAsync(PaginationParams @params, string search = null);
    }
}
