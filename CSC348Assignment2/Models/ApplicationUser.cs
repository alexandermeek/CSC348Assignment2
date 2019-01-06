<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
>>>>>>> ff5b90ea17cd91c1067a9ab9244fb68f918a54b7

namespace CSC348Assignment2.Models
{
    public class ApplicationUser : IdentityUser
    {
<<<<<<< HEAD
        public ApplicationUser() : base() { }
=======
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
>>>>>>> ff5b90ea17cd91c1067a9ab9244fb68f918a54b7
    }
}
