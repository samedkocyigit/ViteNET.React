using Microsoft.EntityFrameworkCore;
using ViteNET.React.Infrastructure.Repositories;
using ViteNET.React.Domain.Models.Models;
using ViteNET.React.Exceptions;
using ViteNET.React.Infrastructure.Repositories.GenericRepository;

namespace ViteNET.React.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ToDoAppContext _context;
        public UserRepository(ToDoAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
