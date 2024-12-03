using Dapper;
using Kursinis.IRepositories;
using Kursinis.Models;
using Microsoft.Data.SqlClient;

namespace Kursinis.Repositories
{
    public class NaudotojaiRepository:INaudotojaiRepository
    {
        private readonly string _connectionString;
        public NaudotojaiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Naudotojas>> GautiVisusAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Naudotojas>("SELECT * FROM Naudotojas");
        }
        public async Task<Naudotojas?> GautiPagalIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Naudotojas>("SELECT * FROM Naudotojas WHERE Id = @Id", new { Id = id });
        }
        public async Task<IEnumerable<Naudotojas>> GautiVisusKlientusPagalKnygaAsync(int knygosId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
            SELECT DISTINCT Naudotojas.* FROM Naudotojas
            JOIN NuomosIrasas ON Naudotojas.Id = NuomosIrasas.NaudotojoId
            WHERE NuomosIrasas.KnygosId = @KnygosId";
            return await connection.QueryAsync<Naudotojas>(sql, new { KnygosId = knygosId });
        }

        public async Task PridetiAsync(Naudotojas naudotojas)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Naudotojas (Id, Vardas, ElPastas, SukurimoData) VALUES (@Id, @Vardas, @ElPastas, GETDATE())";
            await connection.ExecuteAsync(sql, naudotojas);
        }
    }
}
