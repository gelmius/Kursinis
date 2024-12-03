using Kursinis.Models;

namespace Kursinis.IRepositories
{
    public interface IKnygosRepository
    {
        Task<IEnumerable<Knyga>> GautiVisasAsync();
        Task<Knyga?> GautiPagalIdAsync(int id);
        Task PridetiAsync(Knyga knyga);
        Task PašalintiAsync(int id);
        Task<IEnumerable<Knyga>> GautiPagalKategorijaAsync(string kategorija);
        Task<IEnumerable<Knyga>> GautiLaisvasKnygasAsync(DateTime data);
    }
}
