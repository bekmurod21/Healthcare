using HealthCare.Domain.Entities;

namespace HealthCare.Data.IRepositories;

public interface IExersciseRepository
{
    ValueTask<Exercise> InsertExerciseAsync(Exercise exercise);
    ValueTask<Exercise> UpdateExerciseAsync(long id, Exercise exercise);
    ValueTask<bool> DeleteExerciseAysnyc(long id);
    ValueTask<Exercise> SelectExerciseAsync(Predicate<Exercise> predicate);
    IQueryable<Exercise> SelectAllExercise();
    
}

