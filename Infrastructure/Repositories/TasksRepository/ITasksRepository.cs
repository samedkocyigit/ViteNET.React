using ViteNET.React.Domain.Models.Models;
using static ViteNET.React.Infrastructure.Repositories.GenericRepository.IGenericRepository;

namespace ViteNET.React.Infrastructure.Repositories.TasksRepository
{
    public interface ITasksRepository : IGenericRepository<Tasks>
    {
        Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(int id);
    }
}
