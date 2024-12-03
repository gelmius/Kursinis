using Kursinis.IRepositories;
using Kursinis.IServices;
using Kursinis.Models;

namespace Kursinis.Services
{
    public class NuomaService : INuomaService
    {
        private readonly INuomaRepository _nuomosRepository;
        public NuomaService(INuomaRepository nuomosRepository)
        {
            _nuomosRepository = nuomosRepository;
        }
        public async Task<IEnumerable<NuomosIrasas>> GautiVisasNuomosIrasusAsync()
        {
            return await _nuomosRepository.GautiVisasAsync();
        }
        public async Task PridetiNuomosIrasaAsync(NuomosIrasas nuoma)
        {
            await _nuomosRepository.PridetiAsync(nuoma);
        }

        public async Task UzbaigtiNuomaAsync(int nuomosId)
        {
            await _nuomosRepository.UzbaigtiNuomaAsync(nuomosId);
        }
        public async Task<NuomosIrasas?> GautiAktyviaNuomaPagalNaudotojaAsync(int naudotojoId)
        {
            return await _nuomosRepository.GautiAktyviaNuomaPagalNaudotojaAsync(naudotojoId);
        }
        public async Task<IEnumerable<NuomosIrasas>> GautiVisasNuomasPagalNaudotojaAsync(int naudotojoId)
        {
            return await _nuomosRepository.GautiVisasNuomasPagalNaudotojaAsync(naudotojoId);
        }
    }
}
