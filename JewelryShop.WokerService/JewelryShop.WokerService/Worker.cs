using Microsoft.Data.SqlClient;

namespace JewelryShop.WokerService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public Worker(ILogger<Worker> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

				UpdateDatabase();

				await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
			}
		}

		private void UpdateDatabase()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					string query = "UPDATE YourTable SET YourColumn = 'YourValue' WHERE YourCondition";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						_logger.LogInformation($"{rowsAffected} rows updated.");
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating the database.");
			}
		}
	}
}
