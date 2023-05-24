using System;
using AzureFunctionEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionEF.Data
{
	public class Context : DbContext
	{
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("Books");
        }
    }
}