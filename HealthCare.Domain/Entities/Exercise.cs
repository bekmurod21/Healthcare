using HealthCare.Domain.Commons;

namespace HealthCare.Domain.Entities;

public class Exercise:Auditable
{
    public string ExerciseName { get; set; }
    public int Count { get; set; }
}
