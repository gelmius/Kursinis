namespace Kursinis.Models
{
    public class NuomosIrasas : BaseEntity
    {
        public int KnygosId { get; set; }
        public int NaudotojoId { get; set; }
        public DateTime NuomosPradziosData { get; set; }
        public DateTime? NuomosPabaigosData { get; set; }
    }
}
