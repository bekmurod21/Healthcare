using AutoMapper;
using HealthCare.Data.IRepositories;
using HealthCare.Domain.Configurations;
using HealthCare.Domain.Entities;
using HealthCare.Service.DTOs;
using HealthCare.Service.Helpers;
using HealthCare.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using HealthCare.Data.Repositories;
using HealthCare.Service.Extensions;

namespace HealthCare.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository = new UserRepository();
    private readonly IMapper mapper;
    public UserService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async ValueTask<Response<User>> AddStepAsync(User user, long id)
    {
        var person = await this.userRepository.SelectUserAsync(person => person.Id.Equals(id));
        if (user is null)
            return new Response<User>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = null
            };
        var updatedUser =  user.Step;
        var mappedUsers = this.mapper.Map<User>(updatedUser);
        return new Response<User>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedUsers
        };
    }

    public async ValueTask<Response<UserDto>> AddUserAsync(UserForCreationDto userForCreationDto)
    {
        var user = await this.userRepository.SelectUserAsync(user =>
            user.UserName.Equals(userForCreationDto.UserName) ||
            user.PhoneNumber.Equals(userForCreationDto.PhoneNumber));

        if (user is not null)
            return new Response<UserDto>
            {
                StatusCode = 404,
                Message = "User is already existed",
                Result = (UserDto)user
            };
        var mappedUser = this.mapper.Map<User>(userForCreationDto);
        mappedUser.Password = userForCreationDto.Password.Encrypt();
        var addedUser = await this.userRepository.InsertUserAsync(mappedUser);
        var resultDto = this.mapper.Map<UserDto>(addedUser);
        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteUserAsync(long id)
    {
        User user = await this.userRepository.SelectUserAsync(user => user.Id.Equals(id));
        if (user is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = false
            };

        await this.userRepository.DeleteUserAysnyc(id);
        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Result = true
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllUserAsync(PaginationParams @params, string search = null)
    {
        var users = await this.userRepository.SelectAllUsers().ToPagedList(@params).ToListAsync();
        if (users.Any())
            return new Response<List<UserDto>>
            {
                StatusCode = 404,
                Message = "Success",
                Result = null
            };

        var result = users.Where(user => user.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase));
        var mappedUsers = this.mapper.Map<List<UserDto>>(result);
        return new Response<List<UserDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedUsers
        };
    }

    public async ValueTask<Response<UserDto>> GetUserByIdAsync(long id)
    {
        User user = await this.userRepository.SelectUserAsync(user => user.Id.Equals(id));
        if (user is null)
            return new Response<UserDto>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = null
            };

        var mappedUsers = this.mapper.Map<UserDto>(user);
        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedUsers
        };
    }

    public async ValueTask<Response<UserDto>> GetUserByNameAsync(string name)
    {

        User user = await this.userRepository.SelectUserAsync(user => user.FirstName.Equals(name));
        if (user is null)
            return new Response<UserDto>
            {
                StatusCode = 404,
                Message = "Couldn't find for given ID",
                Result = null
            };

        var mappedUsers = this.mapper.Map<UserDto>(user);
        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Result = mappedUsers
        };
    }

    public async ValueTask<Response<User>> ModifyUserAsync(long id, User user)
    {
        var entityToUpdate = await userRepository.SelectUserAsync(u => u.Id == id);

        if (entityToUpdate is null)
        {
            return new Response<User>();
        }
        else if (await userRepository.SelectUserAsync(u => u.LastName == user.LastName) is not null)
        {
            return new Response<User>
            {
                Message = "Username has to be unique"
            };
        }

        entityToUpdate.UpdatedAt = DateTime.UtcNow;
        entityToUpdate.LastName = user.LastName;
        entityToUpdate.Password = user.Password;
        entityToUpdate.FirstName = user.FirstName;
        entityToUpdate.UserName = user.UserName;
        entityToUpdate.PhoneNumber = user.PhoneNumber;
        entityToUpdate.Email = user.Email;
        entityToUpdate.BirthOfDate = user.BirthOfDate;
        entityToUpdate.Height = user.Height;
        entityToUpdate.Weight = user.Weight;
        entityToUpdate.Jins = user.Jins;
        entityToUpdate.Role = user.Role;

        var updatedEntity = await userRepository.UpdateUserAsync(id, entityToUpdate);

        return new Response<User>
        {
            StatusCode = 200,
            Message = "Ok",
            Result = updatedEntity
        };
    }
}
