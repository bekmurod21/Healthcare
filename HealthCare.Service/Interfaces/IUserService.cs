using HealthCare.Domain.Entities;
using HealthCare.Service.Helpers;
namespace HealthCare.Service.Interfaces
{
    public interface IUserService
    {
        public Task<Response<User>> CreateAsync(User user);

        public Task<Response<User>> UpdateAsync(long id, User user);

        public Task<Response<User>> GetByIdAsync(long id);

        public Task<Response<User>> GetByNameAsync(string name);

        public Task<Response<List<User>>> GetAllAsync();

        public Task<Response<bool>> DeleteAsync(long id);
        public Task<Response<User>> AddStepAsync(User user,long id);
    }
}
