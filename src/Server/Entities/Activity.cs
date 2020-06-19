using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentalHealthBar.Server.Entities
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public List<ActivityEntry> ActivityEntries { get; set; } = new List<ActivityEntry>();
    }
}