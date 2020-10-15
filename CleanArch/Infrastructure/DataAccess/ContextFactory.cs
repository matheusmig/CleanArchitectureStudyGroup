using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<CleanArchContext>
    {

        public CleanArchContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();

            DbContextOptionsBuilder<CleanArchContext> builder = new DbContextOptionsBuilder<CleanArchContext>();
            Console.WriteLine(connectionString);
            builder.UseSqlite(connectionString);
            builder.EnableSensitiveDataLogging();
            return new CleanArchContext(builder.Options);
        }

        private static string ReadDefaultConnectionStringFromAppSettings()
        {
            string? envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{envName}.json", false)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
            return connectionString;
        }
    }
}
