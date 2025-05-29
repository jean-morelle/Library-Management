using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;
using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Application.Service;
using Library_Management.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices clientServices;

        public ClientController(IClientServices clientServices)
        {
            this.clientServices = clientServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = await clientServices.ObtenirTousLesClients();
            client.ConvertToDto();
            return Ok(client);
        }
        [HttpGet("Id")]
        public async Task<IActionResult>GetClientById(Guid id)
        {
            var client = await clientServices.ObtenirClientParId(id);
            client.ConverToClient();
            return Ok(client);
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(AddClientDto addClientDto)
        {
            var client = addClientDto.Convert();
            await clientServices.AjouterClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new {id =client.Id},client);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] UpdateClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Les données du client sont requises.");
            }

            var clientExistant = await clientServices.ObtenirClientParId(id);
            if (clientExistant == null)
            {
                return NotFound("Client non trouvé.");
            }

            clientExistant.UpdateClientDto(clientDto);
            await clientServices.MettreAjoursClientAsync(clientExistant);

            return NoContent(); // 204
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            var client = await clientServices.ObtenirClientParId(id);
            if(client is null)
            {
                return NotFound();
            }
            else
            {
                await clientServices.SupprimerClientAsync(id);
            }
            return NoContent();
        }
    }
}

