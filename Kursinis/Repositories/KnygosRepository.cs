using Dapper;
using Kursinis.IRepositories;
using Kursinis.Models;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace Kursinis.Repositories
{
    public class KnygosRepository: IKnygosRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<KnygosRepository> _logger;
        public KnygosRepository(IConfiguration configuration, ILogger<KnygosRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }
        public async Task<IEnumerable<Knyga>> GautiVisasAsync()
        {
            try
            {
                _logger.LogDebug("Executing GautiVisasAsync");
                using var connection = new SqlConnection(_connectionString);
                var knygos = await connection.QueryAsync<Knyga>("SELECT * FROM Knyga");
                _logger.LogInformation("Successfully retrieved all knygos");
                return knygos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while executing GautiVisasAsync");
                throw;
            }
        }
        public async Task<Knyga?> GautiPagalIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Knyga>("SELECT * FROM Knyga WHERE Id = @Id", new { Id = id });
        }
        public async Task PridetiAsync(Knyga knyga)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Knyga (Id, Pavadinimas, Autorius, Kategorija, NuomosKaina, SukurimoData) VALUES (@Id, @Pavadinimas, @Autorius, @Kategorija, @NuomosKaina, GETDATE())";
            await connection.ExecuteAsync(sql, knyga);
        }
        public async Task PašalintiAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Knyga WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Knyga>> GautiPagalKategorijaAsync(string kategorija) 
        { 
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Knyga>("SELECT * FROM Knyga WHERE Kategorija = @Kategorija", new { Kategorija = kategorija });
        }

        public async Task<IEnumerable<Knyga>> GautiLaisvasKnygasAsync(DateTime data)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Knyga>("SELECT k.* FROM Knyga k INNER JOIN NuomosIrasas ni on ni.KnygosId = k.Id  WHERE ni.NuomosPabaigosData <> NULL and ni.NuomosPabaigosData < @Data", new { Data = data });
        }
    }
}
