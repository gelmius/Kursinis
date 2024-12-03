using Kursinis.Models;

namespace Kursinis.IServices
{
    public interface IKnygosService
    {
        Task<IEnumerable<Knyga>> GautiVisasKnygasAsync();
        Task<Knyga?> GautiKnygaPagalIdAsync(int id);
        Task PridetiKnygaAsync(Knyga knyga);
        Task PašalintiKnygaAsync(int id);
        Task<IEnumerable<Knyga>> GautiKnygasPagalKategorijaAsync(string kategorija);
        Task<IEnumerable<Knyga>> GautiLaisvasKnygasAsync(DateTime data);
    }
}
