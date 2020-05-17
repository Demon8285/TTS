using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TTS.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; } = Guid.NewGuid();
        [Required]
        public string ProjectName { get; set; }
        public string About { get; set; }
        [ForeignKey("User")]
        public string UserId;
        public ApplicationUser User { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();

    }
    public class extendedProject : Project
    {
        public double SumTask
        {
            get { return Tasks.Select(x => x.TaskTime).Sum(); }
        }
        public string GetColor
        {
            get
            {
                if (Tasks.All(x => x.TaskStatus) && Tasks.Count() > 0)
                {
                    return "bg-success";
                }
                else if(Tasks.Select(x => x.TaskTime).Sum() > 0)
                {
                    return "bg-info";
                }
                else
                {
                    return "bg-danger";
                }
            }
        }
    }
}
