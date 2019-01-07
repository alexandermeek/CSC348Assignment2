﻿using System;
using System.Collections.Generic;
using System.Text;
using CSC348Assignment2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSC348Assignment2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CSC348Assignment2.Models.Post> Post { get; set; }
        public DbSet<CSC348Assignment2.Models.Comment> Comment { get; set; }
    }
}
