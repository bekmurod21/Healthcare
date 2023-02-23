using HealthCare.Domain.Entities;
using HealthCare.Service.Interfaces;
using HealthCare.Service.Services;


namespace HealthCare.Presentation.UserUi
{
    public class UserUi
    {
        private User userAccount;
        public UserUi(User userA)
        {
            userAccount = userA;
        }
        private IUserService userService = new UserService();

        public async Task UserPage()
        {
            while (true)
            {
                MainDom:
                Console.WriteLine($"1. My Profil   \n" + $"                  Step: {userAccount.Step}\n" + $"                  Cal: {userAccount.Cal}\n" + $"  " + $"            Km: {userAccount.Km}\n");
                Console.WriteLine("Enter 1 to access My profile:");
                int number = int.Parse( Console.ReadLine() );
                if (number == 1)
                {
                    Console.WriteLine("====================================================================================================================================");
                    Console.WriteLine($"Id: {userAccount.Id} Name: {userAccount.FirstName} LastName: {userAccount.LastName} BirthOfDate: {userAccount.BirthOfDate} UserName: {userAccount.UserName}");
                    Console.WriteLine($"Email: {userAccount.Email} Phone Number: {userAccount.PhoneNumber} MaleOrFemale: {userAccount.Jins}" +
                        $"Height: {userAccount.Height} Weight: {userAccount.Weight} CreatedAt: {userAccount.CreatedAt} ");
                    Console.WriteLine("\nClick any button to return to the main menu: ");
                    Console.ReadKey();
                    goto MainDom;
                }
            }
        }
    }
}
