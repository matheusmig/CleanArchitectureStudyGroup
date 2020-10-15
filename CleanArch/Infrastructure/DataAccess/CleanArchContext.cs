using System;
using System.Collections.Generic;
using System.Text;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public sealed class CleanArchContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CleanArchContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchContext).Assembly);
            //SeedData.Seed(modelBuilder);
        }
    }
}
