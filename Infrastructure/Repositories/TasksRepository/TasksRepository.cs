using Microsoft.EntityFrameworkCore;
using ViteNET.React.Infrastructure.Repositories;
using ViteNET.React.Domain.Models.Models;
using ViteNET.React.Exceptions;
using ViteNET.React.Infrastructure.Repositories.GenericRepository;


namespace ViteNET.React.Infrastructure.Repositories.TasksRepository
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        private readonly ToDoAppContext _context;
        public TasksRepository(ToDoAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _context.Tasks
                           .Where(t => t.UserId == userId)
                           .ToListAsync();
            if (tasks.Count == 0)
                throw new ErrorExceptions("There is no task with that userId ");



            return tasks;
        }
    }
}
