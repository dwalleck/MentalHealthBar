using MentalHealthBar.Server.Contexts;
using MentalHealthBar.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalHealthBar.Server.Services
{
    public class ActivityEntriesRepository : IActivityEntriesRepository
    {
        private readonly MentalHealthBarContext _context;
        private readonly ILogger<ActivityEntriesRepository> _logger;

        public ActivityEntriesRepository(MentalHealthBarContext context,
            ILogger<ActivityEntriesRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool ActivityEntryExists(Guid id) => _context.ActivityEntries.Any(e => e.Id == id);

        public void AddActivityEntry(ActivityEntry activityEntry)
        {
            if (activityEntry == null)
            {
                throw new ArgumentNullException(nameof(activityEntry));
            }
            _context.ActivityEntries.Add(activityEntry);
        }

        public void DeleteActivityEntry(ActivityEntry activityEntry)
        {
            if (activityEntry == null)
            {
                throw new ArgumentNullException(nameof(activityEntry));
            }
            _context.ActivityEntries.Remove(activityEntry);
        }

        public async Task<IEnumerable<ActivityEntry>> GetActivityEntriesAsync()
        {
            return await _context.ActivityEntries
                .Include(e => e.Activity)
                .ToListAsync();
        }

        public async Task<ActivityEntry> GetActivityEntryAsync(Guid id)
        {
            return await _context.ActivityEntries
                .Include(e => e.Activity)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public void UpdateActivityEntry(ActivityEntry activityEntry)
        {
            _context.Entry(activityEntry).State = EntityState.Modified;
        }
    }
}
