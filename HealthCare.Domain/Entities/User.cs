

using HealthCare.Domain.Commons;
using HealthCare.Domain.Enums;

namespace HealthCare.Domain.Entities
{
    public class User:Auditable
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthOfDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public MaleOrFemale Jins { get; set; }
        public UserRole Role { get; set; }
        public int Height { get; set; }
        public float Weight { get; set; }
        public long Step { get; set; }
        public decimal Cal { get; set; }
        public decimal Km { get; set; }
        
    }
}
