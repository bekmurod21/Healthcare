using HealthCare.Domain.Entities;
using HealthCare.Service.API;
using HealthCare.Service.Helpers;

namespace HealthCare.Service.Interfaces
{
    public interface IApiService
    {
        Task<Response<List<Users>>> GetAllUsersInformationFromApiAsync(); 
    }
}
