using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vision.SharedUltilities.Global;

namespace Vision.Models.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        #region DbSet
        public virtual DbSet<User> User { get; set; }
        #endregion

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionGlobal.DatabaseConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.username);
                e.Property(x => x.username).HasMaxLength(100);
                e.Property(x => x.password).HasMaxLength(4000);
                e.Property(x => x.hashKey).HasMaxLength(4000);
            });
        }
        #endregion
    }
}
