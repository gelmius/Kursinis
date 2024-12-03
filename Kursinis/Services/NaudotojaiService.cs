using Kursinis.IRepositories;
using Kursinis.IServices;
using Kursinis.Models;

namespace Kursinis.Services
{
    public class NaudotojaiService:INaudotojaiService
    {
        private readonly INaudotojaiRepository _naudotojuRepository;
        public NaudotojaiService(INaudotojaiRepository naudotojuRepository)
        {
            _naudotojuRepository = naudotojuRepository;
        }
        public async Task<IEnumerable<Naudotojas>> GautiVisusNaudotojusAsync()
        {
            return await _naudotojuRepository.GautiVisusAsync();
        }
        public async Task<Naudotojas?> GautiNaudotojaPagalIdAsync(int id)
        {
            return await _naudotojuRepository.GautiPagalIdAsync(id);
        }
        public async Task<IEnumerable<Naudotojas>> GautiVisusKlientusPagalKnygaAsync(int knygosId)
        {
            return await _naudotojuRepository.GautiVisusKlientusPagalKnygaAsync(knygosId);
        }

        public async Task PridetiNaudotojaAsync(Naudotojas naudotojas)
        {
            await _naudotojuRepository.PridetiAsync(naudotojas);
        }
    }
}
