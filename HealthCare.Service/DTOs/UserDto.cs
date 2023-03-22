using HealthCare.Domain.Entities;
using HealthCare.Domain.Enums;

namespace HealthCare.Service.DTOs;

public class UserDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthOfDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public MaleOrFemale Jins { get; set; }
    public int Height { get; set; }
    public float Weight { get; set; }
    public static explicit operator UserDto(User user)
    {
        return new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            BirthOfDate = user.BirthOfDate,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Height = user.Height,
            Weight = user.Weight,
            Jins = user.Jins
        };
    }
}
