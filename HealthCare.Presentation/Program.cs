using HealthCare.Data.Repositories;
using HealthCare.Domain.Entities;
using HealthCare.Service.Interfaces;
using HealthCare.Service.Services;

Console.WriteLine("salom");


UserRepository userRepository = new UserRepository();
User Bekmurod = new User()
{
    FirstName = "Bek21",
    LastName = "Boqijonov",
    BirthOfDate = "21.25.2004",
    Email = "boqiyev4@gmail.com",
    Height = 172,
    Jins = HealthCare.Domain.Enums.MaleOrFemale.male,
    PhoneNumber = "918480521",
    Password = "password1",
    Role = HealthCare.Domain.Enums.UserRole.Admin,
    Weight = 65,
    UserName = "Bekmurod21"
    
};
//await userRepository.InsertUserAsync(Bekmurod);
//await userRepository.UpdateUserAsync(4,Bekmurod);
 var a=userRepository.SelectAllUsers();
Console.WriteLine(  a);