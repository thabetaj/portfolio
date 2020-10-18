using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>()
                .HasOne<User>(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId);


            modelBuilder.Entity<UserUniversity>().HasKey(x => new { x.UniversityiId, x.DegreeId, x.UserId });

            modelBuilder.Entity<UserUniversity>()
            .HasOne<University>(uu => uu.University)
            .WithMany(u => u.UserUniversities)
            .HasForeignKey(uu => uu.UniversityiId);

            modelBuilder.Entity<UserUniversity>()
            .HasOne<Degree>(uu => uu.Degree)
            .WithMany(d => d.UserUniversities)
            .HasForeignKey(uu => uu.DegreeId);

            modelBuilder.Entity<UserUniversity>()
            .HasOne<User>(uu => uu.User)
            .WithMany(u => u.UserUniversities)
            .HasForeignKey(uu => uu.UserId);

            // configures many-to-many relationship
            modelBuilder.Entity<UserTechnicalSkills>().HasKey(x => new { x.userId, x.TechnicalSkillsId });

            modelBuilder.Entity<UserTechnicalSkills>()
            .HasOne<User>(us => us.user)
            .WithMany(u => u.UserTechnicalSkills)
            .HasForeignKey(us => us.userId);

            modelBuilder.Entity<UserTechnicalSkills>()
            .HasOne<TechnicalSkills>(us => us.technicalSkills)
            .WithMany(s => s.UserTechnicalSkills)
            .HasForeignKey(us => us.TechnicalSkillsId);

            modelBuilder.Entity<UserInterpersonalSkills>().HasKey(x => new { x.userId, x.InterpersonalSkillsId });

            modelBuilder.Entity<UserInterpersonalSkills>()
            .HasOne<User>(us => us.user)
            .WithMany(u => u.UserInterpersonalSkills)
            .HasForeignKey(us => us.userId);

            modelBuilder.Entity<UserInterpersonalSkills>()
            .HasOne<InterpersonalSkills>(us => us.interpersonalSkills)
            .WithMany(s => s.UserInterpersonalSkills)
            .HasForeignKey(us => us.InterpersonalSkillsId);
        }


        public DbSet<University> Universities { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<UserUniversity> UserUniversitiess { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TechnicalSkills> TechnicalSkills { get; set; }
        public DbSet<InterpersonalSkills> InterpersonalSkills { get; set; }
        public DbSet<UserTechnicalSkills> UserTechnicalSkills { get; set; }
        public DbSet<UserInterpersonalSkills> UserInterpersonalSkills { get; set; }

    }
}
