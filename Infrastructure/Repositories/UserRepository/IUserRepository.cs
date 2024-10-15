using ViteNET.React.Domain.Models.Models;
using static ViteNET.React.Infrastructure.Repositories.GenericRepository.IGenericRepository;

namespace ViteNET.React.Infrastructure.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);

    }
}
