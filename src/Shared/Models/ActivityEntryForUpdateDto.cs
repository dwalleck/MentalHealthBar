using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalHealthBar.Shared.Models
{
    public class ActivityEntryForUpdateDto
    {
        [Required]
        public Guid ActivityId { get; set; }

        [Required]
        public DateTimeOffset RecordedAt { get; set; }
    }
}
