using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalHealthBar.Server.Services
{
    public interface IActivitiesRepository
    {
        Task<IEnumerable<Entities.Activity>> GetActivitiesAsync();

        Task<Entities.Activity> GetActivityAsync(Guid id);

        void AddActivity(Entities.Activity activity);

        void DeleteActivity(Entities.Activity activity);

        void UpdateActivity(Entities.Activity activity);

        Task<bool> SaveChangesAsync();

        bool ActivityExists(Guid id);
    }
}