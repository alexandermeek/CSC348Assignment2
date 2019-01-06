using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string rolename) : base(rolename)
        {

        }

        public ApplicationRole(string rolename, string desc)
            : base(rolename)
        {
            this.description = desc;
        }

        public string description { get; set; }
    }
}
