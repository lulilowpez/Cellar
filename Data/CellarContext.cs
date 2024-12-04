using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CellarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Cata> Catas { get; set; }

        public CellarContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User Lul = new User()
            {
                Id = 1,
                UserName = "Luli",
                Password = "Luli1234",
                Rol = Enums.Role.Admin
            };
            modelBuilder.Entity<User>().HasData(data: Lul);

            modelBuilder.Entity<Cata>()
                  .HasMany(c => c.WineList)
                  .WithMany(w => w.Catas)
                  .UsingEntity(r => r.ToTable("RelCW"));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cata>(entity =>
            {
                entity.Property(c => c.GuestList)
                    .HasConversion(
                        v => string.Join(",", v), // De List<string> a string
                        v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList() // De string a List<string>
                    );
            });


            modelBuilder.Entity<User>()
               .HasIndex(u => u.UserName)
                 .IsUnique();
            modelBuilder.Entity<User>()
           .HasKey(u => u.Id);


        }
    }
}
        
