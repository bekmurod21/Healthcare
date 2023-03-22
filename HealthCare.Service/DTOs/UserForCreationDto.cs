using HealthCare.Domain.Entities;
using HealthCare.Domain.Enums;

namespace HealthCare.Service.DTOs;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string BirthOfDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public MaleOrFemale Jins { get; set; }
    public int Height { get; set; }
    public float Weight { get; set; }
}
