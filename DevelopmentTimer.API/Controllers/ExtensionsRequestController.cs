using DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.BAL.Managers;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTimer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtensionsRequestController : Controller
    {
        private readonly IExtensionsRequestManager extensionsRequestManager;

        public ExtensionsRequestController(IExtensionsRequestManager extensionsRequestManager)
        {
            this.extensionsRequestManager = extensionsRequestManager;
        }
        [HttpGet]
        public async Task<ActionResult<List<ExtensionsRequestReadDto>>> GetAllExtensionRequests()
        {
            var extensionRequest = await extensionsRequestManager.GetAllExtensionsRequestAsync();
            return Ok(extensionRequest);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> GetExtensionsRequestById(int id)
        {
            var extensionRequest = await extensionsRequestManager.GetByExtensionsRequestIdAsync(id);
            if (extensionRequest == null) return NotFound($"Extension Request with Id = {id} can not be found");
            return Ok(extensionRequest);
        }
        [HttpGet("taskItemId/{taskItemId}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> GetExtensionRequestByTaskItemId(int taskItemId)
        {
            var extensionRequest = await extensionsRequestManager.GetByExtensionsRequestTaskItemIdAsync(taskItemId);
            if (extensionRequest == null || !extensionRequest.Any()) return NotFound($"No Extension Request has been added for TaskItem with Id = {taskItemId}");
            return Ok(extensionRequest);
        }
        [HttpGet("developerId/{developerId}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> GetExtensionRequestByDeveloperId(int developerId)
        {
            var extensionRequest = await extensionsRequestManager.GetByExtensionsRequestDeveloperIdAsync(developerId);
            if (extensionRequest == null || !extensionRequest.Any()) return NotFound($"No Extension Request has been added by developer with Id = {developerId}");
            return Ok(extensionRequest);
        }
        [HttpGet("extraHours/{extraHours}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> GetExtensionRequestByExtraHours(int extraHours)
        {
            var extensionRequest = await extensionsRequestManager.GetByExtensionsRequestExtraHoursAsync(extraHours);
            if (extensionRequest == null || !extensionRequest.Any()) return NotFound($"No Extension Request for extraHours = {extraHours} has been made");
            return Ok(extensionRequest);
        }
        [HttpGet("justification/{justification}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> GetExtensionRequestByJustification(string justification)
        {
            var extensionRequest = await extensionsRequestManager.GetByExtensionsRequestJustificationAsync(justification);
            if (extensionRequest == null || !extensionRequest.Any()) return NotFound($"No justification = {justification} has been provided for any Extension Request");
            return Ok(extensionRequest);
        }

        [HttpPost]
        public async Task<ActionResult<ExtensionsRequestReadDto>> CreateExtensionRequests([FromBody] ExtensionsRequestCreateDto extensionsRequestCreateDto)
        {
            try
            {
                var extensionRequest = await extensionsRequestManager.CreateExtensionsRequestAsync(extensionsRequestCreateDto);
                return Ok(extensionRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> UpdateExtensionRequest(int id, [FromBody] ExtensionsRequestUpdateDto extensionsRequestUpdateDto)
        {
            if (id != extensionsRequestUpdateDto.Id)
                return BadRequest("Id mismatch");
            var extensionRequest = await extensionsRequestManager.UpdateExtensionsRequestAsync(extensionsRequestUpdateDto);
            if (extensionRequest == null)
                return BadRequest($"Update not possible. Extension Request with Id = {id} does not exist");
            return Ok(extensionRequest);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExtensionsRequestReadDto>> DeleteExtensionRequest(int id)
        {
            try
            {
                var extensionRequest = await extensionsRequestManager.DeleteExtensionsRequestAsync(id);
                if (!extensionRequest)
                    return NotFound($"Extension Request with Id = {id} does not exist");
                return Ok($"Extension Request with Id = {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
