using HealthCare.Data.IRepositories;
using HealthCare.Data.Repositories;
using HealthCare.Domain.Entities;
using HealthCare.Service.Helpers;
using HealthCare.Service.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace HealthCare.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> genericRepository = new Repository<User>();

        public async Task<Response<User>> AddStepAsync(User user,long id)
        {
            
            var model = await genericRepository.GetByIdAsync(id);
            if (model == null)
            {
                return new Response<User>()
                {
                    StatusCode = 403,
                    Message = "User not found",
                    Result = null
                };
            }
            
             model = new User()
            {
                Id= id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthOfDate = user.BirthOfDate,
                UpdatedAt = DateTime.Now,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Height = user.Height,
                Weight = user.Weight,
                Jins = user.Jins,
                Role = user.Role,
                UserName = user.UserName,
                Step = user.Step,
                Cal =user.Step/33,
                Km = user.Step/100000m,
            };

            var result = await genericRepository.UpdateAsync(user.Id, model);
            return new Response<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<User>> CreateAsync(User user)
        {
            var models = await this.genericRepository.GetAllAsync();
            var model = models.FirstOrDefault(x => x.FirstName == user.FirstName);
            if (model is not null)
            {
                
                await genericRepository.UpdateAsync(model.Id, model);

                return new Response<User>()
                {
                    StatusCode = 403,
                    Message = "User already exists",
                    Result = null
                };
            }

            var mappedModel = new User()
            {
                FirstName = user.FirstName,
                LastName= user.LastName,
                BirthOfDate= user.BirthOfDate,
                CreatedAt = DateTime.Now,
                Email= user.Email,
                Password= user.Password,
                PhoneNumber= user.PhoneNumber,
                Height= user.Height,
                Weight= user.Weight,
                Jins= user.Jins,
                Role= user.Role,
                UserName= user.UserName,
            };
            var result = await this.genericRepository.CreateAsync(mappedModel);

            return new Response<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Result = false
                };

            await this.genericRepository.DeleteAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = true
            };
        }

        public async Task<Response<List<User>>> GetAllAsync()
        {
            var result = await this.genericRepository.GetAllAsync();
            return new Response<List<User>>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<User>> GetByIdAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<User>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Result = null
                };

            return new Response<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = model
            };
        }

        public async Task<Response<User>> GetByNameAsync(string name)
        {
            var models = await this.genericRepository.GetAllAsync();
            var model =  models.FirstOrDefault(x=>x.FirstName==name);
            if (model is null)
                return new Response<User>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Result = null
                };

            return new Response<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = model
            };
        }

        public async Task<Response<User>> UpdateAsync(long id, User user)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<User>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Result = null
                };

            var Model = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthOfDate = user.BirthOfDate,
                UpdatedAt = DateTime.Now,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Height = user.Height,
                Weight = user.Weight,
                Jins = user.Jins,
                Role = user.Role,
                UserName = user.UserName,
            };

            var result = await this.genericRepository.UpdateAsync(id,Model);
            return new Response<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }
    }
}
