using System;
using AzureFunctionEF.Data;
using AzureFunctionEF.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionEF
{
    public class DefaultFunction
    {
        private readonly ILogger _logger;
        private readonly Context _context;

        public DefaultFunction(ILoggerFactory loggerFactory, Context context)
        {
            _logger = loggerFactory.CreateLogger<DefaultFunction>();
            _context = context;
        }

        [Function("DefaultFunction")]
        public async Task RunAsync([TimerTrigger("0 */1 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var id = Guid.NewGuid();

            await _context.Books.AddAsync(new Book
            {
                Id = id,    
                Name = $"Book_{id}"
            });

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}

