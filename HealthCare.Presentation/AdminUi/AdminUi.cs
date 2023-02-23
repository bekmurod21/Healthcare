using HealthCare.Domain.Entities;
using HealthCare.Domain.Enums;
using HealthCare.Service.Interfaces;
using HealthCare.Service.Services;

namespace ECommerce.Presentation.AdminUI
{

    public class AdminUI
    {
        private User adminAccount;
        public AdminUI(User adminA)
        {
            adminAccount = adminA;
        }
        private IUserService userService = new UserService();
       
        public async Task Admin()
        {
            while (true)
            {
                Console.WriteLine("         Main Menu   ");
                Console.WriteLine("1.Search User");
                Console.WriteLine("2.Get All Users");
                Console.WriteLine("3.Delete User\n" +
                    "4. Edit a user's details\n" +
                    "5. Log out from account");
                Console.Write("Enter the number of your chosen department: ");
                int number = int.Parse(Console.ReadLine());

                if (number == 1)
                {
                    await SearchAsync();
                }
                else if (number == 2)
                {
                    await GetAsync();
                }
                else if (number == 3)
                {
                    await DeleteUserAsync();
                }
                
                else if (number == 4)
                {
                    await Edit();
                }
                else if (number == 5)
                {
                    return;
                }
            }
        }

        private async Task Edit()
        {
            while (true)
            {
                Console.Write("Enter the id of the product you want to update, \"Q\" to exit: ");
                int numid;
                try
                {
                    numid = int.Parse(Console.ReadLine());
                }
                catch
                {
                    return;
                }

                var response = await userService.GetByIdAsync(numid);

                if (response.StatusCode == 404)
                {
                    Console.WriteLine("There is no such user.");
                    Console.Clear();
                    continue;
                }
                var oldmodel = response.Result;
                Console.WriteLine($"Id: {oldmodel.Id}");
                Console.WriteLine($"Name: {oldmodel.FirstName} Lastname: {oldmodel.LastName}");
                Console.WriteLine($"UserRole: {oldmodel.Role}, Username: {oldmodel.UserName}, Password: {oldmodel.Password}");

                Console.WriteLine();
                Console.WriteLine("1. FirstName Update ");
                Console.WriteLine("2. Lastname Update");
                Console.WriteLine("3. UserRole Update");
                Console.WriteLine("4. Username Update ");
                Console.WriteLine("5. Password Update ");
                Console.WriteLine("6.Return Main menu");
                Console.WriteLine();
                Console.Write("Enter the sequence of numbers separated by space to update: ");

                int[] num = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                if (Array.IndexOf(num, 6) != -1)
                {
                    Console.Clear();
                    return;
                }

                //Name Update 
                if (Array.IndexOf(num, 1) != -1)
                {
                    Console.Write("Enter new Fistname: ");
                    oldmodel.FirstName = Console.ReadLine();
                    Console.Clear();
                }

                // Price update
                if (Array.IndexOf(num, 2) != -1)
                {
                    Console.Write("Enter new Lastname: ");
                    oldmodel.FirstName = Console.ReadLine();
                    Console.Clear();
                }

                //discription update
                if (Array.IndexOf(num, 3) != -1)
                {
                    Console.Write("Enter new role for the user: ");
                    Console.WriteLine("1. Customer\n" +
                        "2. Merchant\n" +
                        "3. Admin\n");
                    int rolenumber = int.Parse(Console.ReadLine());

                    oldmodel.Role = (UserRole)((rolenumber - 1) * 10);
                    Console.Clear();
                }

                //Catecgoryid update
                if (Array.IndexOf(num, 4) != -1)
                {
                    Console.Write("Enter new username for the user: ");
                    oldmodel.UserName = Console.ReadLine();

                    Console.Clear();
                }

                // Deliver update
                if (Array.IndexOf(num, 5) != -1)
                {
                    Console.Write("Enter new password for the user: ");
                    oldmodel.UserName = Console.ReadLine();

                    Console.Clear();
                }
            }
        }

        public async Task SearchAsync()
        {
        Get:
            Console.WriteLine($"1.Search by id\n" +
                $"2.Search by name\n" +
                $"~. To return main menu\n\n");

            Console.Write("Enter the part number you want to search: ");
            string number = Console.ReadLine();
            while (true)
            {
                if (number == "1")
                {
                    Console.Write("Enter the user id you want to search for: ");
                    int num = int.Parse(Console.ReadLine());
                    var model = await userService.GetByIdAsync(num);

                    if (model.StatusCode == 404)
                    {
                        Console.WriteLine("User not found.");
                        continue;
                    }

                    Console.WriteLine($"Id: {model.Result.Id} Name: {model.Result.FirstName} LastName: {model.Result.LastName} BirthOfDate: {model.Result.BirthOfDate} UserName: {model.Result.UserName}");
                    Console.WriteLine($"Email: {model.Result.Email} Phone Number: {model.Result.PhoneNumber} MaleOrFemale: {model.Result.Jins} \n" +
                        $"Height: {model.Result.Height} Weight: {model.Result.Weight} CreatedAt: {model.Result.CreatedAt} ");

                    Console.ReadKey();
                    goto Get;
                }
                else if (number == "2")
                {
                    Console.Write("Enter the product name you want to search for: ");
                    string namesearch = Console.ReadLine();
                    var model = await userService.GetByNameAsync(namesearch);
                    if (model.StatusCode == 404)
                    {
                        Console.WriteLine(model.Message);
                        continue;
                    }
                    Console.WriteLine($"Id: {model.Result.Id} Name: {model.Result.FirstName} LastName: {model.Result.LastName} BirthOfDate: {model.Result.BirthOfDate} UserName: {model.Result.UserName}");
                    Console.WriteLine($"Email: {model.Result.Email} Phone Number: {model.Result.PhoneNumber} MaleOrFemale: {model.Result.Jins}\n" +
                        $"Height: {model.Result.Height} Weight: {model.Result.Weight} CreatedAt: {model.Result.CreatedAt} ");

                    Console.ReadKey();
                    goto Get;
                }
                else
                {
                    return;
                }
            }
        }
        public async Task GetAsync()
        {
            var model = await userService.GetAllAsync();
            foreach (var item in model.Result)
            {
                Console.WriteLine("====================================================================================");
                Console.WriteLine($"Id: {item.Id} Name: {item.FirstName} LastName: {item.LastName} BirthOfDate: {item.BirthOfDate} UserName: {item.UserName}");
                Console.WriteLine($"Email: {item.Email} Phone Number: {item.PhoneNumber} MaleOrFemale: {item.Jins}\n" +
                    $"Height: {item.Height} Weight: {item.Weight} CreatedAt: {item.CreatedAt} ");

            }
            Console.ReadKey();

        }
        public async Task DeleteUserAsync()
        {
            Console.Write("Enter the id of the User you want to delete: ");
            int deleteid = int.Parse(Console.ReadLine());
            var model = await userService.DeleteAsync(deleteid);
            if (model.Result == true)
            {
                Console.WriteLine("Deleted.");
            }
            else
            {
                Console.WriteLine("User is not found");
            }

            Console.Write("Press any key to return main menu.");
            Console.ReadKey(true);
        }
    }
}
