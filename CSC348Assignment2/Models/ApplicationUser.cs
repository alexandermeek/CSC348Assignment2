using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CSC348Assignment2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(15)]
        public string Username { get; set; }

        [Display(Name = "Created On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TimeCreated
        {
            get
            {
                return TimeCreated;
            }
            set
            {
                TimeCreated = DateTime.Now;
            }
        }
    }
}
