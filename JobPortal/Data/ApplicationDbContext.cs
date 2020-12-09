using System;
using System.Collections.Generic;
using System.Text;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Applicant>()
                .HasKey(p => new {p.JobId, p.UserId});
        }

        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
    }
}