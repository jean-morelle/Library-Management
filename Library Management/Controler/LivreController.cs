using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Extension;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll()
        {
            var livre = await livreService.ObtenirLesLivresAsync();
            livre.ConvertToDto();
            return Ok(livre);
        }
        [HttpGet("Id")]
        public async Task<IActionResult>GetById(Guid Id)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(Id);
            livre.ConvertTo();
            return Ok(livre);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddLivreDto addLivreDto)
        {
            var livre = addLivreDto.ConvertToAdd();
            await livreService.AjouterLivreAsync(livre);
            return CreatedAtAction(nameof(GetById),new {id =livre.Id},livre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(Guid id,UpdateLivreDTO updateLivreDTO)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            if(livre is null)
            {
                NotFound();
            }
            else
            {
                livre .UpdateLivre(updateLivreDTO);
                await livreService.MettreAjoursLivreAsync(livre);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            if(livre is null)
            {
                NotFound();
            }
            else
            {
                await livreService.SupprimerLivreAsync(id);
            }
            return NoContent();
        }
    }
}
