using Football.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            if (!dbContext.IsConfigured)
            {
                dbContext.UseSqlServer(@"Server=DESKTOP-PFI6MSV\SQLEXPRESS;Database=FootballSeed;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<TeamFights>()
                .HasOne(p => p.Players)
                .WithMany(t => t.Teams)
                .HasForeignKey(p => p.IdPlayerWhyScored);
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<TeamFights> TeamFights { get; set; }

    }
}
