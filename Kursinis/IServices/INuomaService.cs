using Kursinis.Models;

namespace Kursinis.IServices
{
    public interface INuomaService
    {
        Task<IEnumerable<NuomosIrasas>> GautiVisasNuomosIrasusAsync();
        Task PridetiNuomosIrasaAsync(NuomosIrasas nuoma);
        Task UzbaigtiNuomaAsync(int nuomosId);
        Task<NuomosIrasas?> GautiAktyviaNuomaPagalNaudotojaAsync(int naudotojoId);
        Task<IEnumerable<NuomosIrasas>> GautiVisasNuomasPagalNaudotojaAsync(int naudotojoId);
    }
}
