using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Extension;
using Library_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreEmprunterController : ControllerBase
    {
        private readonly IEmpruntServices empruntServices;

        public LivreEmprunterController(IEmpruntServices empruntServices)
        {
            this.empruntServices = empruntServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivreEmpruntReadDto>>> GetAll()
        {
            var emprunts = await empruntServices.ObtenirLesLivresEmpruntersAsync();
            return Ok(emprunts.ConvertToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivreEmpruntReadDto>> GetById(Guid id)
        {
            var emprunt = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            if (emprunt is null)
            {
                return NotFound("Emprunt non trouvé.");
            }
            return Ok(emprunt.ConvertTo());
        }

        [HttpPost]
        public async Task<ActionResult<LivreEmpruntReadDto>> Add(AddLivreEmpruntDto addLivreEmpruntDto)
        {
            var emprunt = addLivreEmpruntDto.ConverToAdd();
            await empruntServices.LivreEmprunters(emprunt);

            var cree = await empruntServices.ObtenirLivreEmprunterParIdAsync(emprunt.Id);
            return CreatedAtAction(nameof(GetById), new { id = emprunt.Id }, cree!.ConvertTo());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivreEmprunter(Guid id, UpdateLivreEmpruntDto updateLivreEmpruntDto)
        {
            var emprunt = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            if (emprunt is null)
            {
                return NotFound("Emprunt non trouvé.");
            }

            emprunt.Update(updateLivreEmpruntDto);
            await empruntServices.MettreAjoursLesLivresEprunterAsync(emprunt);
            return NoContent();
        }

        // Marque le livre comme rendu (date de retour effective = maintenant)
        [HttpPut("{id}/retour")]
        public async Task<IActionResult> Retourner(Guid id)
        {
            await empruntServices.RetournerLivreAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var emprunt = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            if (emprunt is null)
            {
                return NotFound("Emprunt non trouvé.");
            }

            await empruntServices.SupprimerLesLivresEmprunters(id);
            return NoContent();
        }
    }
}
