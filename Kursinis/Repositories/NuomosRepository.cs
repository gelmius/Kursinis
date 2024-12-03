using Dapper;
using Kursinis.IRepositories;
using Kursinis.Models;
using Microsoft.Data.SqlClient;

namespace Kursinis.Repositories
{
    public class NuomosRepository:INuomaRepository
    {
        private readonly string _connectionString;
        public NuomosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<NuomosIrasas>> GautiVisasAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<NuomosIrasas>("SELECT * FROM NuomosIrasas");
        }
        public async Task PridetiAsync(NuomosIrasas nuoma)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO NuomosIrasas (Id, KnygosId, NaudotojoId, NuomosPradziosData, NuomosPabaigosData, SukurimoData) VALUES (@Id, @KnygosId, @NaudotojoId, @NuomosPradziosData, @NuomosPabaigosData, GETDATE())";
            await connection.ExecuteAsync(sql, nuoma);
        }
        public async Task UzbaigtiNuomaAsync(int nuomosId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE NuomosIrasas SET NuomosPabaigosData = @NuomosPabaigosData WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = nuomosId, NuomosPabaigosData = DateTime.UtcNow });
        }

        public async Task<NuomosIrasas?> GautiAktyviaNuomaPagalNaudotojaAsync(int naudotojoId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<NuomosIrasas>("SELECT * FROM NuomosIrasas WHERE NaudotojoId = @NaudotojoId AND NuomosPabaigosData IS NULL", new { NaudotojoId = naudotojoId });
        }
        public async Task<IEnumerable<NuomosIrasas>> GautiVisasNuomasPagalNaudotojaAsync(int naudotojoId)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<NuomosIrasas>("SELECT * FROM NuomosIrasas WHERE NaudotojoId = @NaudotojoId", new { NaudotojoId = naudotojoId });
        }

       
    }
}

