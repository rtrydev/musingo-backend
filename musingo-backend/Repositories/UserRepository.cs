using Microsoft.EntityFrameworkCore;
using musingo_backend.Data;
using musingo_backend.Models;

namespace musingo_backend.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserById(int id);
    public Task<User?> LoginUser(string login, string password);
    public Task<User?> AddUser(User user);
    
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(RepositoryContext context) : base(context) { }


    public async Task<User?> GetUserById(int id)
    {
        var result = await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<User?> LoginUser(string login, string password)
    {
        var result = await GetAll().FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
        return result;
    }

    public async Task<User?> AddUser(User user)
    {
        var result = await AddAsync(user);
        return result;
    }
}