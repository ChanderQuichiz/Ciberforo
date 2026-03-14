using System;
using System.Net.Http.Headers;
using ciberforo.Data;
using ciberforo.Dtos;
using ciberforo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ciberforo.Services;

public class UserService : IUserService
{
    private readonly CiberforoContext context;

    public UserService(CiberforoContext context)
    {
     this.context = context;   
    }

    public async Task<bool> delete(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user != null)
        {
            user.IsDeleted = true;
            user.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<UserDto?> findById(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
       
        if(user != null)
        {
            UserDto userDto = new UserDto(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email
            );
            return userDto;
        }
        
        return null;
    }

    public async Task<UserDto?> login(UserLoginDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);
        if(user != null)
        {
            UserDto userDto = new UserDto(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email
            );
            return userDto;
        }
        return null;
    }

    public async Task<UserDto?> create(UserCreateDto dto)
    {
        if (!dto.Email.Contains("@cibertec.edu.pe"))
        {
            return null;
        }
        User entity = new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Role = UserRole.USER,
            IsBanned = false,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();
        
        UserDto userDto = new UserDto(
            Id: entity.Id,
            FirstName: entity.FirstName,
            LastName: entity.LastName,
            Email: entity.Email
        );
        return userDto;
    }

    public async Task<UserDto?> update(UserUpdateDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == dto.Id);
        if (user != null)
        {
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Password = dto.Password;
            user.UpdatedAt = DateTime.UtcNow;

           await context.SaveChangesAsync();

            UserDto userDto = new UserDto(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email
            );
            return userDto;
        }
        return null;
    }

    public async Task<bool> banned(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user != null)
        {
            user.IsBanned = true;
            user.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<UserDto?> findByEmail(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email+"@cibertec.edu.pe");
        if(user != null)        {
            UserDto userDto = new UserDto(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email
            );
            return userDto;
        }
        return null;
    }
}
