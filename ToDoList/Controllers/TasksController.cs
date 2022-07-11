using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TasksController(ITaskService service)
        {
            this.taskService = service;
        }
        [HttpGet("get-tasks")]
        public IActionResult GetTasks()
        {
            var result = taskService.GetTasks();
            return Ok(result);
        }
        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskViewModel model)
        {
            var result = await taskService.CreateTask(model);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
        [HttpDelete("delete-task/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await taskService.RemoveTask(id);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
        [HttpPut("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var result = await taskService.ChangeStatus(id);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
    }
}
