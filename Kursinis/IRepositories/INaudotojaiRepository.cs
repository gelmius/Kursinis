using Kursinis.Models;

namespace Kursinis.IRepositories
{
    public interface INaudotojaiRepository
    {
        Task<IEnumerable<Naudotojas>> GautiVisusAsync();
        Task<Naudotojas?> GautiPagalIdAsync(int id);

        Task<IEnumerable<Naudotojas>> GautiVisusKlientusPagalKnygaAsync(int knygosId);
        Task PridetiAsync(Naudotojas naudotojas);
    }
}
