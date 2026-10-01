using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Extension;
using Library_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly ILivreService livreService;

        public LivreController(ILivreService livreService)
        {
            this.livreService = livreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivreReadDto>>> GetAll()
        {
            var livres = await livreService.ObtenirLesLivresAsync();
            return Ok(livres.ConvertToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivreReadDto>> GetById(Guid id)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            if (livre is null)
            {
                return NotFound("Livre non trouvé.");
            }
            return Ok(livre.ConvertTo());
        }

        [HttpPost]
        public async Task<ActionResult<LivreReadDto>> AddBook(AddLivreDto addLivreDto)
        {
            var livre = addLivreDto.ConvertToAdd();
            await livreService.AjouterLivreAsync(livre);
            return CreatedAtAction(nameof(GetById), new { id = livre.Id }, livre.ConvertTo());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateLivreDTO updateLivreDTO)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            if (livre is null)
            {
                return NotFound("Livre non trouvé.");
            }

            livre.UpdateLivre(updateLivreDTO);
            await livreService.MettreAjoursLivreAsync(livre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            if (livre is null)
            {
                return NotFound("Livre non trouvé.");
            }

            await livreService.SupprimerLivreAsync(id);
            return NoContent();
        }
    }
}
