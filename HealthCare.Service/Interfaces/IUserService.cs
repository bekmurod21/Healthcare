using HealthCare.Domain.Configurations;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;
using HealthCare.Service.Helpers;
namespace HealthCare.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<Response<UserDto>> AddUserAsync(UserForCreationDto userForCreationDto);
        ValueTask<Response<User>> ModifyUserAsync(long id, User user);
        ValueTask<Response<bool>> DeleteUserAsync(long id);
        ValueTask<Response<UserDto>> GetUserByIdAsync(long id);
        ValueTask<Response<List<UserDto>>> GetAllUserAsync(PaginationParams @params, string search = null);
        ValueTask<Response<UserDto>> GetUserByNameAsync(string name);
        ValueTask<Response<User>> AddStepAsync(User user,long id);
    }
}
