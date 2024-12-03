using Kursinis.IServices;
using Kursinis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kursinis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnygosController : ControllerBase
    {
        private readonly IKnygosService _knyguService;
        private readonly ILogger<KnygosController> _logger;
        public KnygosController(IKnygosService knyguService, ILogger<KnygosController> logger)
        {
            _knyguService = knyguService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knyga>>> GautiVisasKnygas()
        {
            _logger.LogDebug("Received GET request for all knygos");
            var knygos = await _knyguService.GautiVisasKnygasAsync();
            _logger.LogInformation("Successfully handled GET request for all knygos");
            return Ok(knygos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Knyga>> GautiKnygaPagalId(int id)
        {
            var knyga = await _knyguService.GautiKnygaPagalIdAsync(id);
            if (knyga == null)
            {
                return NotFound();
            }
            return Ok(knyga);
        }

        [HttpGet("kategorija/{kategorija}")]
        public async Task<ActionResult<Knyga>> GautiKnygaPagalKategorija(string kategorija)
        {
            var knyga = await _knyguService.GautiKnygasPagalKategorijaAsync(kategorija);
            if (knyga == null)
            {
                return NotFound();
            }
            return Ok(knyga);
        }

        [HttpGet("Laisvos/{data?}")]
        public async Task<ActionResult<Knyga>> GautiLaisvasKnygas(DateTime data)
        {

            var knyga = await _knyguService.GautiLaisvasKnygasAsync(data);
            if (knyga == null)
            {
                return NotFound();
            }
            return Ok(knyga);
        }

        [HttpPost]
        public async Task<ActionResult> PridetiKnyga([FromBody] Knyga knyga)
        {
            await _knyguService.PridetiKnygaAsync(knyga);
            return CreatedAtAction(nameof(GautiKnygaPagalId), new { id = knyga.Id }, knyga);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> PašalintiKnyga(int id)
        {
            await _knyguService.PašalintiKnygaAsync(id);
            return NoContent();
        }
    }
}
