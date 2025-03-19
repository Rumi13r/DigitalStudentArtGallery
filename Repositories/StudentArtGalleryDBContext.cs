using DigitalStudentArtGallery.Entities;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DigitalStudentArtGallery.Repositories
{
    public class StudentArtGalleryDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PostsEntities> Posts { get; set; }
        public DbSet<CommentsEntities> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object optsql = optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSiteDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                FirstName = "admin",
                LastName = "admin",
                IsAdmin = true
            });

            modelBuilder.Entity<User>()
                .HasAlternateKey(nameof(User.Username));
        }
    }
}
