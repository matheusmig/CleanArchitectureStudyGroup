using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public static class SeedData
    {

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new { Id = 1, Name = new Name("Romulo Correa"), Birthdate = new Birthdate(new DateTime(2000, 5, 6)) }
                );
        }
    }
}
