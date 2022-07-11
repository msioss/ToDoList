using ToDoList.Data.EFContext;
using ToDoList.Data.Entities;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Services
{
    public interface ITaskBlockService
    {
        IEnumerable<TaskBlock> GetTaskBlocks();
        Task<ServiceResponceModel<TaskBlock>> CreateTaskBlock(CreateTaskBlockViewModel model);
        Task<ServiceResponceModel<int>> RemoveTaskBlock(int id);
        Task<ServiceResponceModel<int>> ChangeName(EditTaskBlockViewModel model);
    }
    public class TaskBlockService : ITaskBlockService
    {
        private readonly DBContext context;
        public TaskBlockService(DBContext context)
        {
            this.context = context;
        }

        public IEnumerable<TaskBlock> GetTaskBlocks()
        {
            return context.TaskBlocks;
        }

        public async Task<ServiceResponceModel<TaskBlock>> CreateTaskBlock(CreateTaskBlockViewModel model)
        {
            var taskBlock = new TaskBlock
            {
                Name = model.Name
            };

            var result = await context.TaskBlocks.AddAsync(taskBlock);
            await context.SaveChangesAsync();

            if (result == null)
            {
                return new ServiceResponceModel<TaskBlock> { IsSuccess = false, Error = $"Task block can not be added ", Responce = null };
            }
            return new ServiceResponceModel<TaskBlock> { IsSuccess = true, Error = "", Responce = taskBlock };
        }

        public async Task<ServiceResponceModel<int>> RemoveTaskBlock(int id)
        {
            var taskBlock = context.TaskBlocks.First(t => t.Id == id);
            var result = context.TaskBlocks.Remove(taskBlock);
            await context.SaveChangesAsync();

            if (result == null)
            {
                return new ServiceResponceModel<int> { IsSuccess = false, Error = $"Task block can not be removed ", Responce = 0 };
            }
            return new ServiceResponceModel<int> { IsSuccess = true, Error = "", Responce = id };
        }

        public async Task<ServiceResponceModel<int>> ChangeName(EditTaskBlockViewModel model)
        {
            var taskBlock = context.TaskBlocks.First(t => t.Id == model.Id);
            if (taskBlock == null)
            {
                return new ServiceResponceModel<int> { IsSuccess = false, Error = $"Incorrect task block", Responce = 0 };
            }

            taskBlock.Name = model.Name;
            await context.SaveChangesAsync();

            return new ServiceResponceModel<int> { IsSuccess = true, Error = "", Responce = model.Id };
        }
    }
}
