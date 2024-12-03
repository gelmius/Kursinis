using Kursinis.Models;

namespace Kursinis.IRepositories
{
    public interface INuomaRepository
    {
        Task<IEnumerable<NuomosIrasas>> GautiVisasAsync();
        Task PridetiAsync(NuomosIrasas nuoma);
        Task UzbaigtiNuomaAsync(int nuomosId);
        Task<NuomosIrasas?> GautiAktyviaNuomaPagalNaudotojaAsync(int naudotojoId);
        Task<IEnumerable<NuomosIrasas>> GautiVisasNuomasPagalNaudotojaAsync(int naudotojoId);
        
    }
}
