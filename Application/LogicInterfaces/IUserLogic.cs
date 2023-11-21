using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateUserAsync (UserCreationDto dto);
    Task<User?> GetUserByUsernameAsync (string username);
}