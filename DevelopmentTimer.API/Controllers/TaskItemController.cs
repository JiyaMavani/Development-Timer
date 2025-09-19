using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.BAL.Managers;
using DevelopmentTimer.DAL.Entities;
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
        [HttpGet("title/{title}")]
        public async Task<ActionResult<TaskItemReadDto>> GetTaskItemsByTitle(string title)
        {
            var taskItem = await taskItemManager.GetByTaskItemTitleAsync(title);
            if (taskItem == null || !taskItem.Any()) return NotFound($"TaskItem with Title = {title} can not be found");
            return Ok(taskItem);
        }
        [HttpGet("description/{description}")]
        public async Task<ActionResult<TaskItemReadDto>> GetTaskItemsByDescription(string description)
        {
            var taskItem = await taskItemManager.GetByTaskItemDescriptionAsync(description);
            if (taskItem == null || !taskItem.Any()) return NotFound($"TaskItem with Description = {description} can not be found");
            return Ok(taskItem);
        }
        [HttpGet("estimatedHours/{estimatedHours}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByEstimatedHours(int estimatedHours)
        {
            var taskItems = await taskItemManager.GetByTaskItemEstimatedHoursAsync(estimatedHours);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with Estimated Hours = {estimatedHours} can not be found");
            return Ok(taskItems);
        }
        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByStatus(Status status)
        {
            var taskItems = await taskItemManager.GetByTaskItemStatusAsync(status);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with Status = {status} can not be found");
            return Ok(taskItems);
        }
        [HttpGet("projectId/{projectId}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByProjectId(int projectId)
        {
            var taskItems = await taskItemManager.GetByTaskItemProjectIdAsync(projectId);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No taskItems have been assigned to Project with Id = {projectId}");
            return Ok(taskItems);
        }
        [HttpGet("developerId/{developerId}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByDeveloperId(int developerId)
        {
            var taskItems = await taskItemManager.GetByTaskItemDeveloperIdAsync(developerId);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No taskItems have been assigned to Developer with Id = {developerId}");
            return Ok(taskItems);
        }
        [HttpPost]
        public async Task<ActionResult<TaskItemReadDto>> CreateTaskItems([FromBody] TaskItemCreateDto taskItemCreateDto)
        {
            try
            {
                var taskItem = await taskItemManager.CreateTaskItemAsync(taskItemCreateDto);
                return Ok(taskItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemReadDto>> UpdateTaskItem(int id, [FromBody] TaskItemUpdateDto taskItemUpdateDto)
        {
            if (id != taskItemUpdateDto.Id)
                return BadRequest("Id mismatch.");
            var taskItem = await taskItemManager.UpdateTaskItemAsync(taskItemUpdateDto);
            if (taskItem == null)
                return BadRequest($"Update not possible. TaskItem with Id = {id} does not exist");
            return Ok(taskItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskItems(int id)
        {
            try
            {
                var taskItem = await taskItemManager.DeleteTaskItemAsync(id);
                if (!taskItem)
                    return NotFound($"TaskItem with Id = {id} does not exist.");
                return Ok($"TaskItem with Id = {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
