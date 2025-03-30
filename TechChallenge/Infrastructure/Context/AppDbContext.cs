using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> User { get; set; }

        public AppDbContext(IConfiguration configuration,DbContextOptions<AppDbContext> options)
            : base(options)
        {
            _configuration = configuration;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == "Development")
            {
                Env.Load(); 
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {

                    var host = Environment.GetEnvironmentVariable("DB_HOST") ?? _configuration["DB_HOST"];
                    var port = Environment.GetEnvironmentVariable("DB_PORT") ?? _configuration["DB_PORT"];
                    var database = Environment.GetEnvironmentVariable("DB_NAME") ?? _configuration["DB_NAME"];
                    var username = Environment.GetEnvironmentVariable("DB_USER") ?? _configuration["DB_USER"];
                    var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? _configuration["DB_PASSWORD"];

                    Console.WriteLine($"DB_HOST: {host}");
                    Console.WriteLine($"DB_PORT: {port}");
                    Console.WriteLine($"DB_NAME: {database}");
                    Console.WriteLine($"DB_USER: {username}");
                    Console.WriteLine($"DB_PASSWORD: {password}");

                    connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";
                    optionsBuilder.UseNpgsql(connectionString); 
            }
            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Conectado com sucesso ao banco de dados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
