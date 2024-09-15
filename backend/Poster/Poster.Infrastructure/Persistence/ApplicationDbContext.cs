using Microsoft.EntityFrameworkCore;
using Poster.Application.Interfaces;
using Poster.Domain.Entities;
using Poster.Infrastructure.Data;

namespace Poster.Infrastructure.Persistence
{
    /// <summary>
    /// Контекст данных приложения
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Post> Posts { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(TestData.GetPosts());
        }
    }
}
