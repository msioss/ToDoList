using ToDoList.Data.EFContext;
using ToDoList.Data.Entities;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Services
{
    public interface ITaskService
    {
        IEnumerable<ToDoTask> GetTasks();
        Task<ServiceResponceModel<ToDoTask>> CreateTask(CreateTaskViewModel model);
        Task<ServiceResponceModel<int>> RemoveTask(int id);
        Task<ServiceResponceModel<int>> ChangeStatus(int id);
    }
    public class TaskService : ITaskService
    {
        private readonly DBContext context;
        public TaskService(DBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ToDoTask> GetTasks()
        {
            return context.Tasks;
        }

        public async Task<ServiceResponceModel<ToDoTask>> CreateTask(CreateTaskViewModel model)
        {
            var task = new ToDoTask
            {
                Name = model.Name,
                Status = false,
                TaskBlockId=model.TaskBlockId
            };

            var result = await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            if (result == null)
            {
                return new ServiceResponceModel<ToDoTask> { IsSuccess = false, Error = $"Task can not be added ", Responce = null };
            }
            return new ServiceResponceModel<ToDoTask> { IsSuccess = true, Error = "", Responce = task };
        }

        public async Task<ServiceResponceModel<int>> RemoveTask(int id)
        {
            var task = context.Tasks.First(t => t.Id == id);
            var result = context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            if (result == null)
            {
                return new ServiceResponceModel<int> { IsSuccess = false, Error = $"Task can not be removed ", Responce = 0 };
            }
            return new ServiceResponceModel<int> { IsSuccess = true, Error = "", Responce = id };
        }

        public async Task<ServiceResponceModel<int>> ChangeStatus(int id)
        {
            var task = context.Tasks.First(t => t.Id == id);
            if (task == null)
            {
                return new ServiceResponceModel<int> { IsSuccess = false, Error = $"Incorrect task", Responce = 0 };
            }

            task.Status=!task.Status;
            await context.SaveChangesAsync();

            return new ServiceResponceModel<int> { IsSuccess = true, Error = "", Responce = id };
        }
    }
}
