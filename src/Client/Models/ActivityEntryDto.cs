using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalHealthBar.Client.Models
{
    public class ActivityEntryDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset RecordedAt { get; set; }

        public Guid ActivityId { get; set; }

        public ActivityDto Activity { get; set; }
    }
}
