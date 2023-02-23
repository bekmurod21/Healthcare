using HealthCare.Domain.Entities;
using HealthCare.Domain.Enums;
using HealthCare.Service.Interfaces;
using HealthCare.Service.Services;

namespace ECommerce.Presentation.LoginPageUI
{
    public class LoginPageUI
    {
        private IUserService userService = new UserService();
        
        public  async Task<User> LoginPage()
        {
            while (true)
            {
            main:
                Console.WriteLine("     Main Menu   ");
                Console.WriteLine("1.Sign up");
                Console.WriteLine("2.Sign in");
                Console.WriteLine();
                Console.WriteLine("Enter the number of your chosen department: ");

                string number = Console.ReadLine();



                // Sign Up 
                if (number == "1")
                {
                    Console.Clear();
                    Console.WriteLine("     Sign up ");

                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter your surname: ");
                    string surname = Console.ReadLine();

                    Console.Write("Enter a new login: ");
                    string login = Console.ReadLine();

                    Console.Write("enter you birth: ");
                    string age = Console.ReadLine();

                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();

                    
                    Console.Write("Enter male or female:\n" +
                        "1. male\n" +
                        "2.female\n");
                    string jinChoice = Console.ReadLine();
                    MaleOrFemale jrole = MaleOrFemale.male;

                    Console.Write("Enter your phone number: ");
                    string phoneNumber = Console.ReadLine();
                password10:
                    Console.Write("Enter a new password: ");
                    string password1 = Console.ReadLine();

                    Console.Write("re-enter the password: ");
                    string password2 = Console.ReadLine();

                    
                    if (password1 != password2)
                    {
                        Console.Clear();
                        Console.WriteLine("The passwords you entered do not match. Please re-enter the password");
                        goto password10;
                    }
                    Console.Write("Enter your wight: ");
                    float wight = float.Parse(Console.ReadLine());
                    Console.Write("enter your height: ");
                    int heigh = int.Parse(Console.ReadLine());
                    var person = new User()
                    {
                        FirstName = name,
                        LastName = surname,
                        Email = email,
                        UserName = login,
                        PhoneNumber = phoneNumber,
                        Password = password1,
                        Height = heigh,
                        Weight = wight,
                        BirthOfDate = age,
                        Jins = (MaleOrFemale)(jrole)

                    };

                    Console.WriteLine("salom");
                    var response = await userService.CreateAsync(person);
                    Console.WriteLine("qwer");

                    if (response.StatusCode == 404)
                    {
                        Console.WriteLine("Bunaqa user mavjud");
                        goto main;
                    }
                    else
                    {
                        Console.WriteLine("Created\n");
                        return person;
                        
                    }
                    
                }

                
                else if (number == "2")
                {
                login1:
                    Console.Clear();
                    Console.WriteLine("     Sign in ");
                    Console.Write("Enter your Login or Email: ");
                    string loginoremail = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    var users = await userService.GetAllAsync();
                    var user = users.Result.FirstOrDefault(x=> x.UserName == loginoremail && x.Password==password);
                    if (user is not null)
                    {
                        if (password == user.Password)
                        {
                            Console.WriteLine("Entered");
                            
                            return user;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password or login.");
                            goto login1;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Bunaqa user yo'q.");
                    }
                }
                else if (number == "Bekmurod")
                {
                    Console.Write("Enter the special password: ");
                    string adminPassword = Console.ReadLine();

                    var responses = await userService.GetAllAsync();
                    var response = responses.Result.FirstOrDefault(x => x.Password == adminPassword && x.Role == UserRole.Admin);

                    if (response is not null)
                    {
                        return response;
                    }
                    else
                    {
                        if (adminPassword == "Bekmurod21")
                        {
                            Console.Write("Your special username: ");
                            string un = Console.ReadLine();

                            Console.Write("Your special password: ");
                            string newPassword = Console.ReadLine();

                            Console.Write("Enter your email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter your phone number: ");
                            string phoneNumber = Console.ReadLine();

                            await userService.CreateAsync(new User()
                            {
                                UserName = un,
                                Password = newPassword,
                                Email = email,
                                PhoneNumber = phoneNumber,
                                Role = UserRole.Admin
                            });
                        }
                    }
                    goto main;
                }
            }

        }
    }
}
