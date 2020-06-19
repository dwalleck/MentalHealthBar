using System;
using System.ComponentModel.DataAnnotations;

namespace MentalHealthBar.Server.Entities
{
    public class ActivityEntry
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset RecordedAt { get; set; }

        [Required]
        public Guid ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}