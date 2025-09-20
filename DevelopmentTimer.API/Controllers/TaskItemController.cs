using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (taskItem == null) return NotFound($"TaskItem with Id = {id} not found");
            return Ok(taskItem);
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByTitle(string title)
        {
            var taskItems = await taskItemManager.GetByTaskItemTitleAsync(title);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with Title = {title} not found");
            return Ok(taskItems);
        }

        [HttpGet("description/{description}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByDescription(string description)
        {
            var taskItems = await taskItemManager.GetByTaskItemDescriptionAsync(description);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with Description = {description} not found");
            return Ok(taskItems);
        }

        [HttpGet("estimatedHours/{estimatedHours}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByEstimatedHours(int estimatedHours)
        {
            var taskItems = await taskItemManager.GetByTaskItemEstimatedHoursAsync(estimatedHours);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with EstimatedHours = {estimatedHours} not found");
            return Ok(taskItems);
        }

        [HttpGet("totalHours/{totalHours}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByTotalHours(int totalHours)
        {
            var taskItems = await taskItemManager.GetByTaskItemTotalHoursAsync(totalHours);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with TotalHours = {totalHours} not found");
            return Ok(taskItems);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByStatus(Status status)
        {
            var taskItems = await taskItemManager.GetByTaskItemStatusAsync(status);
            if (taskItems == null || !taskItems.Any()) return NotFound($"TaskItems with Status = {status} not found");
            return Ok(taskItems);
        }

        [HttpGet("projectId/{projectId}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByProjectId(int projectId)
        {
            var taskItems = await taskItemManager.GetByTaskItemProjectIdAsync(projectId);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No TaskItems have been assigned for Project with Id = {projectId}");
            return Ok(taskItems);
        }

        [HttpGet("developerId/{developerId}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByDeveloperId(int developerId)
        {
            var taskItems = await taskItemManager.GetByTaskItemDeveloperIdAsync(developerId);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No TaskItems have been assigned to Developer with Id = {developerId}");
            return Ok(taskItems);
        }

        [HttpGet("isApproved/{isApproved}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByIsApproved(bool isApproved)
        {
            var taskItems = await taskItemManager.GetByTaskItemisApprovedAsync(isApproved);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No TaskItems with Approval Status = {isApproved} is found");
            return Ok(taskItems);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByDate(DateOnly date)
        {
            var taskItems = await taskItemManager.GetByTaskItemDateAsync(date);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No TaskItems for Date = {date} is found");
            return Ok(taskItems);
        }

        [HttpGet("notificationThreshold/{threshold}")]
        public async Task<ActionResult<List<TaskItemReadDto>>> GetTaskItemsByNotificationThreshold(TimeOnly threshold)
        {
            var taskItems = await taskItemManager.GetByTaskItemNotificationThresholdMinutesAsync(threshold);
            if (taskItems == null || !taskItems.Any()) return NotFound($"No TaskItems with NotificationThresholdMinutes = {threshold} is found");
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskItems(int id)
        {
            try
            {
                var result = await taskItemManager.DeleteTaskItemAsync(id);
                if (!result) return NotFound($"TaskItem with Id = {id} does not exist");
                return Ok($"TaskItem with Id = {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
