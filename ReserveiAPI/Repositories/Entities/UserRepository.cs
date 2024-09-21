﻿using Microsoft.EntityFrameworkCore;
using ReserveiAPI.Contexts;
using ReserveiAPI.Objects.Contracts;
using ReserveiAPI.Objects.Models.Entities;
using ReserveiAPI.Repositories.Interfaces;

namespace backend.Repositories.Entities;
public class UserRepository : IUserRepository
{

    private readonly AppDBContext _dbContext;

    public UserRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<UserModel> GetById(int id)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserModel> Login(Login login)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailUser == login.Email && u.PasswordUser == login.Password);
    }

    public async Task<UserModel> Create(UserModel userModel)
    {
        _dbContext.Users.Add(userModel);
        await _dbContext.SaveChangesAsync();

        return userModel;
    }

    public async Task<UserModel> Update(UserModel userModel)
    {
        _dbContext.Entry(userModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return userModel;
    }

    public async Task<UserModel> Delete(UserModel userModel)
    {
        _dbContext.Users.Remove(userModel);
        await _dbContext.SaveChangesAsync();

        return userModel;
    }
}