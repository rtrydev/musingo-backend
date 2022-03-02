using musingo_backend.Data;
using musingo_backend.Models;

namespace musingo_backend.Repositories;

public interface IUserRepository
{
    public Task<ICollection<User>> GetAll();
}

public class UserRepository : Repository<User>
{
    public UserRepository(RepositoryContext context) : base(context) { }
    
    
}