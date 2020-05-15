using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TTS.Entities
{
    [Table("Subscribe")]
    public class Subscribe
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime SubscribeTime { get; set; } = DateTime.Now.AddDays(30);
    }
}
