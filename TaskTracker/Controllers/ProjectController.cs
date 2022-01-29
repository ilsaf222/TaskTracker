using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskTracker.Domain;
using TaskTracker.Domain.Entities;
using TaskTracker.Models;
using TaskTracker.Models.Project;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> repository;
        private readonly IMapper mapper;

        public ProjectController(IRepository<Project> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /*[HttpGet(Name = "GetProject")]
        public async Task<IEnumerable<ListProjectVIewModel>> GetAll()
        {
            return await repository.GetAll()
                .Include(x => x.Objectives)
                .ProjectTo<ListProjectVIewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }*/

        [HttpGet]
        public async Task<IEnumerable<ListProjectVIewModel>> GetOwners([FromQuery] FilterProjectModel filter)
        {
            var projects = repository.GetAll()
                .Include(x => x.Objectives)
                .ProjectTo<ListProjectVIewModel>(mapper.ConfigurationProvider);

            if (filter.NullCheck()) // null check, if nothing is selected and written, we return all data (проверка на null)
            {
                return await projects
                    .ToListAsync();
            }

            if(filter.Status != null)
            {
                projects = projects.Where(x => x.Status == filter.Status);
            }
            if(filter.EndTime != null)
            {
                projects = projects.OrderBy(x => x.EndTime);
            }
            if (filter.StartTime != null)
            {
                projects = projects.OrderBy(x => x.StartTime);
            }
            if (filter.Priority != null)
            {
                projects = projects.OrderBy(x => x.Priority);
            }
            if (filter.Name != null)
            {
                projects = projects.OrderBy(x => x.Name);
            }

            if (string.IsNullOrWhiteSpace(filter.SearchText) == false)
            {
                var normalizedSearch = filter.SearchText.Trim().ToUpper();

                projects = projects
                    .Where(x => x.Name.ToUpper().Contains(normalizedSearch)
                            || x.Description.ToUpper().Contains(normalizedSearch)
                            || x.Priority.ToString().Contains(normalizedSearch));
            }

            return await projects
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListFullInfoProjectViewModel>> GetFullInfo(int id, CancellationToken cancellationToken)
        {
            var project = await repository.GetAll()
                .Where(x => x.Id == id)
                .Include(x => x.Objectives)
                .ProjectTo<ListFullInfoProjectViewModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (project == null)
            {
                return NotFound();
            }

            return project;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var project = new Project()
                {
                    Name = model.Name,
                    Description = model.Description,
                    EndTime = model.EndTime,
                    Priority = model.Priority,
                    StartTime = model.StartTime,
                    Status = model.Status,
                };

                await repository.AddAsync(project, cancellationToken);

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
        {
            var project = await repository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            await repository.RemoveAsync(project, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EditProjectVIewModel model, CancellationToken cancellationToken)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var project = await repository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            project.Name = model.Name;
            project.Description = model.Description;
            project.EndTime = model.EndTime;
            project.Priority = model.Priority;
            project.StartTime = model.StartTime;
            project.Status = model.Status;

            await repository.UpdateAsync(project, cancellationToken);

            return NoContent();
        }
    }
}
