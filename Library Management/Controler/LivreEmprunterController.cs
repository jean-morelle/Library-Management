using Librairi_Management.Domain.Interface;
using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Extension;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreEmprunterController : ControllerBase
    {
        private readonly IEmpruntServices empruntServices;
        private readonly ILivreService livreService;
        private readonly IClientServices clientServices;

        public LivreEmprunterController(IEmpruntServices empruntServices,ILivreService livreService,IClientServices clientServices)
        {
            this.empruntServices = empruntServices;
            this.livreService = livreService;
            this.clientServices = clientServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livreEmprunter = await empruntServices.ObtenirLesLivresEmpruntersAsync();
            var livre = await livreService.ObtenirLesLivresAsync();
            var client = await clientServices.ObtenirTousLesClients();
            var EmpruntDtos = client.ConvertToDto(livre,livreEmprunter);
            return Ok(EmpruntDtos);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var livreEmprunter = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            var livre = await livreService.ObtenirLivreParIdAsync(id);
            var client = await clientServices.ObtenirClientParId(id);

            if (livreEmprunter == null || livre == null || client == null)
            {
                return NotFound("Données introuvables.");
            }

            var empruntDto = client.ConvertTo(livre, livreEmprunter);
            return Ok(empruntDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLivreEmpruntDto addLivreEmpruntDto)
        {
            var livreEmprunter = addLivreEmpruntDto.ConverToAdd();
            await empruntServices.LivreEmprunters(livreEmprunter);
            return CreatedAtAction(nameof(GetById), new {id =livreEmprunter.Id } ,livreEmprunter);
        }
        [HttpPut("Id")]
        public async Task<IActionResult>UpdateLivreEmprunter(Guid id,UpdateLivreEmpruntDto updateLivreEmpruntDto)
        {
            var livreEmprunter = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            if(livreEmprunter is null)
            {
                throw new Exception();
            }
            else
            {
                livreEmprunter.Update(updateLivreEmpruntDto);
                await empruntServices.MettreAjoursLesLivresEprunterAsync(livreEmprunter);
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var livreEmprunter = await empruntServices.ObtenirLivreEmprunterParIdAsync(id);
            if(livreEmprunter is null)
            {
                NotFound();
            }
            else
            {
                await empruntServices.SupprimerLesLivresEmprunters(id);
            }
            return NoContent();
        }
    }
}
