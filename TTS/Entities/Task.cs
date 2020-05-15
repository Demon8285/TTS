using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTS.Entities
{
    [Table("Task")]
    public class Task
    {
        public Guid TaskId { get; set; } = Guid.NewGuid();
        [Required]
        public string TaskName { get; set; }
        public double TaskTime { get; set; } = 0;
        public bool TaskStatus { get; set; } = false;
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
