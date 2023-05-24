using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AzureFunctionEF.Data
{
	public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {

            var index = Array.IndexOf(args, "--connection-string");

            if (index == -1)
                throw new Exception("Parameter --connection-string did not provide");

            string connectionString = args[index + 1];

            Console.WriteLine(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(connectionString);

            return new Context(optionsBuilder.Options);
        }
    }
}

