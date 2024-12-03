using Kursinis.IRepositories;
using Kursinis.IServices;
using Kursinis.Models;

namespace Kursinis.Services
{
    public class KnygosService : IKnygosService
    {
        private readonly IKnygosRepository _knyguRepository;
        public KnygosService(IKnygosRepository knyguRepository)
        {
            _knyguRepository = knyguRepository;
        }
        public async Task<IEnumerable<Knyga>> GautiVisasKnygasAsync()
        {
            return await _knyguRepository.GautiVisasAsync();
        }
        public async Task<Knyga?> GautiKnygaPagalIdAsync(int id)
        {
            return await _knyguRepository.GautiPagalIdAsync(id);
        }
        public async Task PridetiKnygaAsync(Knyga knyga)
        {
            await _knyguRepository.PridetiAsync(knyga);
        }
        public async Task PašalintiKnygaAsync(int id)
        {
            await _knyguRepository.PašalintiAsync(id);
        }
        public async Task<IEnumerable<Knyga>> GautiKnygasPagalKategorijaAsync(string kategorija)
        {
            return await _knyguRepository.GautiPagalKategorijaAsync(kategorija);
        }

        public async Task<IEnumerable<Knyga>> GautiLaisvasKnygasAsync(DateTime data)
        {
            return await _knyguRepository.GautiLaisvasKnygasAsync(data);
        }
    }


}
