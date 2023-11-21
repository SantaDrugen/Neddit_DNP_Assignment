using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;
    
    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    
    public Task<User> CreateUserAsync(UserCreationDto dto)
    {
        User? existing = await _userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
        {
            throw new ArgumentException("Username already exists");
        }

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.UserName,
            Password = dto.Password
        };

        User created = await _userDao.CreateAsync(toCreate);

        return created;
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }



    private static void ValidateData(UserCreationDto userCreationDto)
    {
        string userName = userCreationDto.UserName;
        string passWord = userCreationDto.Password;

        if (userName.Length < 4)
        {
            throw new ArgumentException("Username must be at least 4 characters long");
        }
        
        if (userName.Length > 16)
        {
            throw new ArgumentException("Username must be at most 20 characters long");
        }
        
        if (passWord.Length < 8)
        {
            throw new ArgumentException("Password must be at least 8 characters long");
        }

        if (passWord.Length > 32)
        {
            throw new ArgumentException("Password must be at most 32 characters long");
        }   
    }
}