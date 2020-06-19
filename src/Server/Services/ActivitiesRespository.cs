using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentalHealthBar.Server.Contexts;
using MentalHealthBar.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MentalHealthBar.Server.Services
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly MentalHealthBarContext _context;
        private readonly ILogger<ActivitiesRepository> _logger;

        public ActivitiesRepository(MentalHealthBarContext context,
            ILogger<ActivitiesRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void AddActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }
            _context.Activities.Add(activity);
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityAsync(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public void DeleteActivity(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public bool ActivityExists(Guid id) => _context.Activities.Any(e => e.Id == id);
    }
}