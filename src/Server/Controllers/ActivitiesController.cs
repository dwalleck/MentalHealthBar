using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MentalHealthBar.Server.Entities;
using MentalHealthBar.Server.Contexts;
using MentalHealthBar.Shared.Models;
using MentalHealthBar.Server.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace MentalHealthBar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepository _repository;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivitiesRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivities()
        {
            var activities = await _repository.GetActivitiesAsync();
            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivity(Guid id)
        {
            var activity = await _repository.GetActivityAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(Guid id, ActivityForUpdateDto activity)
        {
            var activityEntity = await _repository.GetActivityAsync(id);
            if (activityEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(activity, activityEntity);
            _repository.UpdateActivity(activityEntity);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> PostActivity(ActivityForCreationDto activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            var activityEntity = _mapper.Map<Activity>(activity);
            _repository.AddActivity(activityEntity);
            await _repository.SaveChangesAsync();

            var activityToReturn = _mapper.Map<ActivityDto>(activityEntity);
            return CreatedAtAction(
                "GetActivity",
                new { id = activityToReturn.Id },
                activityToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityDto>> DeleteActivity(Guid id)
        {
            var activity = await _repository.GetActivityAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            _repository.DeleteActivity(activity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ActivityDto>(activity);
        }
    }
}
