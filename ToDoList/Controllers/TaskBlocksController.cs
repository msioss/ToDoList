using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaskBlocksController : ControllerBase
    {
        private readonly ITaskBlockService blockService;
        public TaskBlocksController(ITaskBlockService service)
        {
            this.blockService = service;
        }
        [HttpGet("get-blocks")]
        public IActionResult GetTasks()
        {
            var result = blockService.GetTaskBlocks();
            return Ok(result);
        }
        [HttpPost("create-block")]
        public async Task<IActionResult> CreateBlock([FromBody] CreateTaskBlockViewModel model)
        {
            var result = await blockService.CreateTaskBlock(model);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
        [HttpDelete("delete-block/{id}")]
        public async Task<IActionResult> DeleteBlock(int id)
        {
            var result = await blockService.RemoveTaskBlock(id);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
        [HttpPut("change-name")]
        public async Task<IActionResult> ChangeName([FromBody] EditTaskBlockViewModel model)
        {
            var result = await blockService.ChangeName(model);
            if (!result.IsSuccess)
            {
                return Conflict(result.Error);
            }
            return Ok(result.Responce);
        }
    }
}
