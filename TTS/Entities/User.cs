using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TTS.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Subscribe { get; set; }
    }
}
