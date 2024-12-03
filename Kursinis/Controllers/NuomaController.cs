using Kursinis.IServices;
using Kursinis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kursinis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NuomaController : ControllerBase
    {
        private readonly INuomaService _nuomosService;
        public NuomaController(INuomaService nuomosService)
        {
            _nuomosService = nuomosService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NuomosIrasas>>> GautiVisasNuomosIrasus()
        {
            var nuomosIrasai = await _nuomosService.GautiVisasNuomosIrasusAsync();
            return Ok(nuomosIrasai);
        }
        [HttpPost]
        public async Task<ActionResult> PridetiNuomosIrasa([FromBody] NuomosIrasas nuoma)
        {
            if(nuoma.NuomosPabaigosData != null && nuoma.NuomosPabaigosData>= nuoma.NuomosPradziosData)
            {
                return BadRequest("Negali buti pradzios data velesne uz pabaigos");
            }

            await _nuomosService.PridetiNuomosIrasaAsync(nuoma);
            return CreatedAtAction(nameof(GautiVisasNuomosIrasus), null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> UzbaigtiNuoma(int id)
        {
            await _nuomosService.UzbaigtiNuomaAsync(id);
            return NoContent();
        }

        [HttpGet("Aktyvi/{id}")]
        public async Task<ActionResult<NuomosIrasas>> GautiAktyviaPagalId(int id)
        {
            var nuoma = await _nuomosService.GautiAktyviaNuomaPagalNaudotojaAsync (id);
            if (nuoma == null)
            {
                return NotFound();
            }
            return Ok(nuoma);
        }

        [HttpGet("Naudotojas/{id}")]
        public async Task<ActionResult<IEnumerable<NuomosIrasas>>> GautiVisusNuomosIrasusPagalNaudotoja(int id)
        {
            var nuomosIrasai = await _nuomosService.GautiVisasNuomasPagalNaudotojaAsync(id);
            if (nuomosIrasai == null)
            {
                return NotFound();
            }
            return Ok(nuomosIrasai);
        }
    }
}
