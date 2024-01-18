using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FastApplicationApi.V1
{
    [Route("api/atas")]
    [ApiController]
    public class AtaController : ControllerBase
    {
        private readonly IAtaService _ataService;

        public AtaController(IAtaService ataService)
        {
            _ataService = ataService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAta([FromBody] Ata model)
        {
            // Implemente a lógica para criar uma Ata
            var ata = await _ataService.CreateAtaAsync(model);
            return CreatedAtAction(nameof(GetAtas), new { id = ata.Id }, ata);
        }

        [HttpPut("{ataId}/colaboradores/{colaboradorId}")]
        public async Task<IActionResult> AddColaboradorToAta(int ataId, int colaboradorId)
        {           
            var result = await _ataService.AddColaboradorToAtaAsync(ataId, colaboradorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpDelete("{ataId}/colaboradores/{colaboradorId}")]
        public async Task<IActionResult> RemoveColaboradorFromAta(int ataId, int colaboradorId)
        {           
            var result = await _ataService.RemoveColaboradorFromAtaAsync(ataId, colaboradorId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAtas([FromQuery] string workshopNome = null, [FromQuery] DateTime? data = null)
        {            
            var atas = await _ataService.GetAtasAsync(workshopNome, data);
            return Ok(atas);
        }
    }
}
