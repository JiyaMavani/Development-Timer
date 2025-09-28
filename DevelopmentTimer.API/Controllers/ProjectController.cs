using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTimer.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProjectController : Controller
    {
        private readonly IProjectManager projectManager;
        public ProjectController(IProjectManager projectManager)
        {
            this.projectManager = projectManager;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectReadDto>>> GetAllProjects()
        {
            var projects = await projectManager.GetAllProjectAsync();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectReadDto>> GetProjectById(int id)
        {
            var project = await projectManager.GetByProjectIdAsync(id);
            if (project == null) return NotFound($"Project with Id = {id} can not be found");
            return Ok(project);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<ProjectReadDto>> GetProjectByName(string name)
        {
            var project = await projectManager.GetByProjectNameAsync(name);
            if (project == null) return NotFound($"Project with name = {name} can not be found");
            return Ok(project);
        }

        [HttpGet("maxHours/{maxHours}")]
        public async Task<ActionResult<List<ProjectReadDto>>> GetProjectByMaxHours(int maxHours)
        {
            var projects = await projectManager.GetByProjectMaxHoursAsync(maxHours);
            if (projects == null || !projects.Any()) return NotFound($"Projects with maxHours = {maxHours} can not be found");
            return Ok(projects);
        }
        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<ProjectReadDto>>> GetProjectByStatus(Status status)
        {
            var projects = await projectManager.GetByProjectStatusAsync(status);
            if (projects == null || !projects.Any()) return NotFound($"Projects with status = {status} can not be found");
            return Ok(projects);
        }

        [HttpGet("developer/{developerId}")]
        public async Task<ActionResult<List<ProjectReadDto>>> GetProjectForDeveloper(int developerId)
        {
            var projects = await projectManager.GetProjectsForDeveloperAsync(developerId);
            if (projects == null || !projects.Any()) return NotFound($"No Projects are assigned to the developer with Id = {developerId}");
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectReadDto>> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var project = await projectManager.CreateProjectAsync(projectCreateDto);
            if (project == null)
                return BadRequest("Project with the same name already exists");
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectReadDto>> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            if (id != projectUpdateDto.Id)
                return BadRequest("Id mismatch");
            var project = await projectManager.UpdateProjectAsync(projectUpdateDto);
            if (project == null)
                return BadRequest($"Update not possible. Project with Id = {id} does not exist");
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                var project = await projectManager.DeleteProjectAsync(id);
                if (!project)
                    return NotFound($"Project with Id = {id} does not exist");
                return Ok($"Project with Id = {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
