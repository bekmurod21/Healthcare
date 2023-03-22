using HealthCare.Data.Context;
using HealthCare.Data.IRepositories;
using HealthCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HealthCare.Data.Repositories
{

    public class ExerciseRepository : IExersciseRepository
    {
        AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteExerciseAysnyc(long id)
        {
            Exercise entity =
            await this.appDbContext.Exercises.FirstOrDefaultAsync(user => user.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Exercises.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<Exercise> InsertExerciseAsync(Exercise exercise)
        {
            EntityEntry<Exercise> entity = await this.appDbContext.Exercises.AddAsync(exercise);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<Exercise> SelectAllExercise()
        {
            var query = "select * from \"Exercise\"";
            return this.appDbContext.Exercises.FromSqlRaw(query); ;
        }

        public async ValueTask<Exercise> SelectExerciseAsync(Predicate<Exercise> predicate)=>
            await this.appDbContext.Exercises.FirstOrDefaultAsync(exercise => predicate(exercise));
        

        public async ValueTask<Exercise> UpdateExerciseAsync(long id, Exercise exercise)
        {
            exercise.Id = id;
            EntityEntry<Exercise> entity = appDbContext.Exercises.Update(exercise);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
