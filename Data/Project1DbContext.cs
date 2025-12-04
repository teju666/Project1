using Microsoft.EntityFrameworkCore;
using Project1.Models.Entities;

namespace Project1.Data
{
    public class Project1DbContext : DbContext
    {
         public Project1DbContext(DbContextOptions<Project1DbContext> options) : base(options)
        {
        
         }

    // DbSet for your Project entity
        public DbSet<Project> Projects { get; set; }
    }
}