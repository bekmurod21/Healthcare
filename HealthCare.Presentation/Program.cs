//using HealthCare.Data.Repositories;
//using HealthCare.Domain.Entities;
//using HealthCare.Service.Interfaces;
//using HealthCare.Service.Services;

//Console.WriteLine("salom");


//UserRepository userRepository = new UserRepository();
//User Bekmurod = new User()
//{
//    FirstName = "Bek21",
//    LastName = "Boqijonov",
//    BirthOfDate = "21.25.2004",
//    Email = "boqiyev4@gmail.com",
//    Height = 172,
//    Jins = HealthCare.Domain.Enums.MaleOrFemale.male,
//    PhoneNumber = "918480521",
//    Password = "password1",
//    Role = HealthCare.Domain.Enums.UserRole.Admin,
//    Weight = 65,
//    UserName = "Bekmurod21"

//};
////await userRepository.InsertUserAsync(Bekmurod);
////await userRepository.UpdateUserAsync(4,Bekmurod);
//var a = userRepository.SelectAllUsers();
//userRepository.SelectAllUsers();

//foreach (var user in userRepository.SelectAllUsers())
//{
//    Console.WriteLine(user.FirstName);
//}

using HealthCare.Service.API;
using Newtonsoft.Json;

using var client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/users?page=2");


if (response.IsSuccessStatusCode)
{
    var json = await response.Content.ReadAsStringAsync();
    var courses = JsonConvert.DeserializeObject<IEnumerable<Users>>(json);
    foreach (var course in courses)
        Console.WriteLine(course.LastName + ". " + course.FirstName);
}
