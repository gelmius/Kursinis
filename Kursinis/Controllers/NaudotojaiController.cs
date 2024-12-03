using Kursinis.IServices;
using Kursinis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kursinis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NaudotojaiController : ControllerBase
    {
        private readonly INaudotojaiService _naudotojuService;
        public NaudotojaiController(INaudotojaiService naudotojuService)
        {
            _naudotojuService = naudotojuService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Naudotojas>>> GautiVisusNaudotojus()
        {
            var naudotojai = await _naudotojuService.GautiVisusNaudotojusAsync();
            return Ok(naudotojai);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Naudotojas>> GautiNaudotojaPagalId(int id)
        {
            var naudotojas = await _naudotojuService.GautiNaudotojaPagalIdAsync(id);
            if (naudotojas == null)
            {
                return NotFound();
            }
            return Ok(naudotojas);
        }

        [HttpPost]
        public async Task<ActionResult> PridetiNaudotoja([FromBody] Naudotojas naudotojas)
        {
            await _naudotojuService.PridetiNaudotojaAsync(naudotojas);
            return CreatedAtAction(nameof(GautiNaudotojaPagalId), new { id = naudotojas.Id }, naudotojas);
        }

        [HttpGet("Knyga/{id}")]
        public async Task<ActionResult<IEnumerable<Naudotojas>>> GautiVisusKlientusPagalKnyga(int id)
        {
            var naudotojai = await _naudotojuService.GautiVisusKlientusPagalKnygaAsync(id);
            return Ok(naudotojai);
        }
    }
}
