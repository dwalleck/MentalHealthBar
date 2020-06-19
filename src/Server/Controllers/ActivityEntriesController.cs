using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MentalHealthBar.Server.Entities;
using MentalHealthBar.Server.Services;
using AutoMapper;
using MentalHealthBar.Shared.Models;

namespace MentalHealthBar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityEntriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivityEntriesRepository _repository;

        public ActivityEntriesController(
            IActivityEntriesRepository repository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityEntry>>> GetActivityEntries()
        {
            var entries = await _repository.GetActivityEntriesAsync();
            return Ok(_mapper.Map<IEnumerable<ActivityEntryDto>>(entries));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityEntryDto>> GetActivityEntry(Guid id)
        {
            var entry = await _repository.GetActivityEntryAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ActivityEntryDto>(entry));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityEntry(Guid id, ActivityEntryForUpdateDto entry)
        {
            var entity = await _repository.GetActivityEntryAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _mapper.Map(entry, entity);
            _repository.UpdateActivityEntry(entity);
            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_repository.ActivityEntryExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ActivityEntryDto>> PostActivityEntry(ActivityEntryForCreationDto entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            var entity = _mapper.Map<ActivityEntry>(entry);
            _repository.AddActivityEntry(entity);
            await _repository.SaveChangesAsync();
            var entryToReturn = _mapper.Map<ActivityEntryDto>(entity);
            return CreatedAtAction("GetActivityEntry", new { id = entryToReturn.Id }, entryToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityEntryDto>> DeleteActivityEntry(Guid id)
        {
            var activityEntry = await _repository.GetActivityEntryAsync(id);
            if (activityEntry == null)
            {
                return NotFound();
            }

            _repository.DeleteActivityEntry(activityEntry);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ActivityEntryDto>(activityEntry);
        }
    }
}
