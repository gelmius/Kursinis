using Kursinis.Models;

namespace Kursinis.IServices
{
    public interface INaudotojaiService
    {
        Task<IEnumerable<Naudotojas>> GautiVisusNaudotojusAsync();
        Task<Naudotojas?> GautiNaudotojaPagalIdAsync(int id);
        Task<IEnumerable<Naudotojas>> GautiVisusKlientusPagalKnygaAsync(int knygosId);
        Task PridetiNaudotojaAsync(Naudotojas naudotojas);
    }
}
