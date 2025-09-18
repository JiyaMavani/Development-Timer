using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.BAL.Managers;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTimer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemManager taskItemManager;

        public TaskItemController(ITaskItemManager taskItemManager)
        {
            this.taskItemManager = taskItemManager;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetAllTaskItems()
        {
            var taskItems = await taskItemManager.GetAllTaskItemAsync();
            return Ok(taskItems);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemReadDto>> GetTaskItemsById(int id)
        {
            var taskItem = await taskItemManager.GetByTaskItemId(id);
            if (taskItem == null) return NotFound($"TaskItem with Id = {id} can not be found");
            return Ok(taskItem);
        }
        
    }
}
