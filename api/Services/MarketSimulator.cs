using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class MarketSimulatorBackgroundService : BackgroundService
    {
        private readonly ILogger<MarketSimulatorBackgroundService> _logger;
        private Models.IMarket _market;
        
        public MarketSimulatorBackgroundService(IServiceProvider serviceProvider, ILogger<MarketSimulatorBackgroundService> logger)
        {
            _logger = logger;            
            _market = serviceProvider.GetService<Models.IMarket>();            
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {                
                _market.Update();
                await Task.Delay(3000, stoppingToken);
            }            
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting!");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping!");
            return base.StopAsync(cancellationToken);
        }
    }
}