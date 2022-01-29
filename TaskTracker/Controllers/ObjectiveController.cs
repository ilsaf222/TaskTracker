using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;
using TaskTracker.Domain.Entities;
using TaskTracker.Models.Objective;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectiveController : ControllerBase
    {
        private readonly IRepository<Objective> repository;
        private readonly IMapper mapper;

        public ObjectiveController(IRepository<Objective> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetObjective")]
        public async Task<IEnumerable<ListObjectiveViewModel>> GetAll() 
        {
            return await repository.GetAll()
                .ProjectTo<ListObjectiveViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListObjectiveViewModel>> GetById(int id, CancellationToken cancellationToken)
        {
            var objective = await repository.GetAll()
                .Where(x => x.Id == id)
                .ProjectTo<ListObjectiveViewModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (objective == null)
            {
                return NotFound();
            }

            return objective;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateObjectiveViewModel model, CancellationToken cancellationToken) 
        {
            if (ModelState.IsValid)
            {
                var objective = new Objective()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Priority = model.Priority,
                    Status = model.Status,
                    ProjectId = model.ProjectId
                };

                await repository.AddAsync(objective, cancellationToken);

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
        {
            var objective = await repository.GetByIdAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            await repository.RemoveAsync(objective, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EditObjectiveViewModel model, CancellationToken cancellationToken) 
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var objective = await repository.GetByIdAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            objective.Name = model.Name;
            objective.Description = model.Description;
            objective.Priority = model.Priority;
            objective.Status = model.Status;

            await repository.UpdateAsync(objective, cancellationToken);

            return NoContent();
        }
    }
}
