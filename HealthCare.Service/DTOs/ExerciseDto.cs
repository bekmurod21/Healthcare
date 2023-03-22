using HealthCare.Domain.Entities;

namespace HealthCare.Service.DTOs;

public class ExerciseDto
{
    public string ExerciseName { get; set; }
    public int Count { get; set; }
    public static explicit operator ExerciseDto(Exercise exercise)
    {
        return new ExerciseDto
        {
            ExerciseName = exercise.ExerciseName,
            Count = exercise.Count
        };
    }
}
