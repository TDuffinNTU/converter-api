using System;
using Microsoft.Extensions.Logging; 

namespace api.Services
{
    public class MyScopedService : IScopedService
    {
        private readonly ILogger<MyScopedService> _logger;
        public Guid ID { get; set; }
        public int counter { get; set; }

        public MyScopedService (ILogger<MyScopedService> logger)
        {
            _logger = logger;
            ID = Guid.NewGuid();
        }      

        public void Write()
        {
            _logger.LogInformation($"MyScopedService with GUID:{ID}");
        }

        
    }

    public interface IScopedService
    {
        void Write();
        public int counter { get; set; }
    }
}