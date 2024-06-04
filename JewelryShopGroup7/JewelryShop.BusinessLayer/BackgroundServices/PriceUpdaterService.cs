using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.BackgroundServices
{
    public class PriceUpdaterService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        private readonly ILogger<PriceUpdaterService> _logger;

        public PriceUpdaterService(HttpClient httpClient, IServiceProvider serviceProvider, ILogger<PriceUpdaterService> logger)
        {
            _httpClient = httpClient;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            // Start the task immediately
            _ = UpdatePricesAsync();

            // Schedule the task to run at midnight every day
            ScheduleDailyTask();
            return Task.CompletedTask;
        }

        private void ScheduleDailyTask()
        {
            var now = DateTime.Now;
            var nextRun = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1);
            var initialDelay = (nextRun - now).TotalMilliseconds;

            _timer = new Timer(async _ => await UpdatePricesAsync(), null, TimeSpan.FromMilliseconds(initialDelay), TimeSpan.FromDays(1));
        }
        private async Task UpdatePricesAsync()
        {
            try
            {
                var metals = await FetchMetalsFromApi();
                var gems = await FetchGemsFromApi();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var materialPriceRepository = scope.ServiceProvider.GetRequiredService<IMaterialPriceRepository>();
                    var materialRepository = scope.ServiceProvider.GetRequiredService<IMaterialRepository>();
                    // Update the database with the new prices
                    foreach (var metal in metals)
                    {
                        var jewelryMaterial = (await materialRepository.GetAsync(m => m.Name.Contains(metal.MetalType) && m.Name.Contains(metal.Purity.ToString()))).FirstOrDefault();
                        if (jewelryMaterial != null)
                        {
                            var materialPrice = new MaterialPrice
                            {
                                MaterialId = jewelryMaterial.MaterialId,
                                //  Date = DateOnly.FromDateTime(DateTime.Now),
                                Date = DateTime.UtcNow,
                                Price = metal.Price,
                                MaterialPriceId = Guid.NewGuid(),
                                UnitType = jewelryMaterial.UnitType,
                            };
                            await materialPriceRepository.AddAsync(materialPrice);
                        }
                    }

                    foreach (var gem in gems)
                    {
                        var jewelryMaterial = (await materialRepository.GetAsync(m => m.Name.Contains(gem.Name) && m.Name.Contains(gem.Carat.ToString()))).FirstOrDefault();
                        if (jewelryMaterial != null)
                        {
                            var materialPrice = new MaterialPrice
                            {
                                MaterialId = jewelryMaterial.MaterialId,
                              //  Date = DateOnly.FromDateTime(DateTime.Now),
                                Date = DateTime.UtcNow,
                                Price = gem.Price,
                                MaterialPriceId = Guid.NewGuid(),
                                UnitType = jewelryMaterial.UnitType,
                            };
                            await materialPriceRepository.AddAsync(materialPrice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                Console.WriteLine($"Error updating prices: {ex.Message}");
            }
        }

        private async Task<List<Metal>> FetchMetalsFromApi()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5227/api/Metal");
            if (response == "[]")
            {
                return new List<Metal>();
            } else {
                return JsonConvert.DeserializeObject<List<Metal>>(response);
            }
        }

        private async Task<List<Gem>> FetchGemsFromApi()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5227/api/Gem");
            if (response == "[]")
            {
                return new List<Gem>();
            } else {
                return JsonConvert.DeserializeObject<List<Gem>>(response);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            await base.StopAsync(stoppingToken);
        }
    }
    public class Metal
    {
        public int MetalId { get; set; }
        public string MetalType { get; set; }
        public double Purity { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
    }

    public class Gem
    {
        public int GemId { get; set; }
        public string Name { get; set; }
        public double Carat { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Cut { get; set; }
        public decimal Price { get; set; }
    }
}
