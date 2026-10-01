using Librairi_Management.Domain.Interface;
using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Extension;
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
        public async Task<ActionResult<IEnumerable<ClientReadDto>>> GetAll()
        {
            var clients = await clientServices.ObtenirTousLesClients();
            return Ok(clients.ConvertToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientReadDto>> GetClientById(Guid id)
        {
            var client = await clientServices.ObtenirClientParId(id);
            if (client is null)
            {
                return NotFound("Client non trouvé.");
            }
            return Ok(client.ConverToClient());
        }

        [HttpPost]
        public async Task<ActionResult<ClientReadDto>> AddClient(AddClientDto addClientDto)
        {
            var client = addClientDto.Convert();
            await clientServices.AjouterClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client.ConverToClient());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, UpdateClientDto clientDto)
        {
            var clientExistant = await clientServices.ObtenirClientParId(id);
            if (clientExistant is null)
            {
                return NotFound("Client non trouvé.");
            }

            clientExistant.UpdateClientDto(clientDto);
            await clientServices.MettreAjoursClientAsync(clientExistant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await clientServices.ObtenirClientParId(id);
            if (client is null)
            {
                return NotFound("Client non trouvé.");
            }

            await clientServices.SupprimerClientAsync(id);
            return NoContent();
        }
    }
}
