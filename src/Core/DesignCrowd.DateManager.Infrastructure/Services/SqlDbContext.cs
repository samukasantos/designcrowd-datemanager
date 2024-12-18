
using DesignCrowd.DateManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignCrowd.DateManager.Infrastructure.Services;

public class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
{
    public DbSet<PublicHoliday> PublicHolidays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PublicHoliday>().HasKey(h => h.Id);
    }
}