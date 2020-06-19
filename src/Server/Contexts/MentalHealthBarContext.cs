using Microsoft.EntityFrameworkCore;
using MentalHealthBar.Server.Entities;

namespace MentalHealthBar.Server.Contexts
{
    public class MentalHealthBarContext : DbContext
    {
        public MentalHealthBarContext(DbContextOptions<MentalHealthBarContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityEntry> ActivityEntries { get; set; }
    }
}