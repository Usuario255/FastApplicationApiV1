using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastApplicationApi.V1
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopsController(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarWorkshopAsync([FromBody] Workshop workshopDto)
        {
            var workshop = await _workshopService.CadastrarWorkshop(workshopDto);
            return CreatedAtAction(nameof(GetWorkshopById), new { id = workshop.Id }, workshop);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkshopById(int id)
        {
            var workshop = await _workshopService.GetWorkshopById(id);
            if (workshop == null)
                return NotFound();

            return Ok(workshop);
        }
    }
}
