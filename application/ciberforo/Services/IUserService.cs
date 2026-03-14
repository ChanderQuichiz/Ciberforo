using System;
using ciberforo.Dtos;
using ciberforo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Services;

public interface IUserService
{
    public Task<UserDto?> create(UserCreateDto dto);
    public Task<UserDto?> findById(int id);
    public Task<UserDto?> login(UserLoginDto dto);
    public Task<UserDto?> update(UserUpdateDto dto);
    public Task<bool> delete(int id);
    public Task<bool> banned(int id);
    public Task<UserDto?> findByEmail(string email);
}
