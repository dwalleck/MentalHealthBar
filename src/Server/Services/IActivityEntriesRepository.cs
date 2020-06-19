using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalHealthBar.Server.Services
{
    public interface IActivityEntriesRepository
    {
        Task<IEnumerable<Entities.ActivityEntry>> GetActivityEntriesAsync();

        Task<Entities.ActivityEntry> GetActivityEntryAsync(Guid id);

        void AddActivityEntry(Entities.ActivityEntry activityEntry);

        void DeleteActivityEntry(Entities.ActivityEntry activityEntry);

        void UpdateActivityEntry(Entities.ActivityEntry activityEntry);

        Task<bool> SaveChangesAsync();

        bool ActivityEntryExists(Guid id);
    }
}
