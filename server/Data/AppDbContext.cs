using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data{
    public class AppDbContext: DbContext{
        public DbSet<User> Users{get; set;}
        public DbSet<Post> Posts{get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        protected override  void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
            .HasIndex(user=>user.Email) //diff between property and hasindex
            .IsUnique();
        }
    }
}