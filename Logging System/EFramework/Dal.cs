using Learn.BL;
using Logging_System.Models;
using Mentors.BL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Logging_System.EFramework
{
    public class Dal:DbContext
    {
        public DbSet<LearnersDetails> learners { get; set; }
        public DbSet<MentorsBL> mentors { get; set; }
        public DbSet<Administrator> admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
                modelBuilder.Entity<LearnersDetails>().ToTable("Learners_Information");
                modelBuilder.Entity <LearnersDetails> ().HasKey(x => x.LearnerID);

                modelBuilder.Entity<MentorsBL>().ToTable("MentorsCredentials");
                modelBuilder.Entity <MentorsBL> ().HasKey(x => x.MentorID);

                modelBuilder.Entity<Administrator>().ToTable("Administrator");
                modelBuilder.Entity<Administrator>().HasKey(x => x.AdminID);
        }
        }
    }
