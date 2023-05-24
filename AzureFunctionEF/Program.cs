using AzureFunctionEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();

builder.ConfigureServices((hostContext, services) =>
{
    string connectionString = hostContext.Configuration.GetSection("ConnectionString").Value!;

    services.AddDbContext<Context>(
        options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
});

builder.Build().Run();