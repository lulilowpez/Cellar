using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CellarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasIndex(U => User.UserName)
            .IsUnique();
    }  
}
