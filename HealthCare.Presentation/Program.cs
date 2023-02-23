

using ECommerce.Presentation.AdminUI;
using ECommerce.Presentation.LoginPageUI;
using HealthCare.Data.Repositories;
using HealthCare.Domain.Entities;
using HealthCare.Domain.Enums;
using HealthCare.Service.Interfaces;
using HealthCare.Service.Services;
using HealthCare.Presentation.UserUi;
while (true)
{
    var login = new LoginPageUI();
    var currentUser = await login.LoginPage();

    if (currentUser.Role == UserRole.User)
    {
        var user = new UserUi(currentUser);
        await user.UserPage();
    }
    else if (currentUser.Role == UserRole.Admin)
    {

        AdminUI admin = new AdminUI(currentUser);
        await admin.Admin();
    }
}


