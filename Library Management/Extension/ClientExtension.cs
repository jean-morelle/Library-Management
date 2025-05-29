using Librairi_Management.Domain.Models;
using Library_Management.Application.AutoMapper.Dto;

namespace Library_Management.Extension
{
    public static class ClientExtension
    {
        public static IEnumerable<ClientReadDto> ConvertToDto(this IEnumerable<Client> clients)
        {
            var result = from client in clients
                         select new ClientReadDto
                         {
                             Id = client.Id,
                             Nom = client.Nom,
                             NumeroTelephone = client.NumeroTelephone,
                             Email = client.Email,
                             Quartier = client.Quartier,
                         };
            return result;
        }

        public static ClientReadDto ConverToClient (this Client client)
        {
            return new ClientReadDto
            {
                Id = client.Id,
                Nom = client.Nom,
                NumeroTelephone = client.NumeroTelephone,
                Email = client.Email,
                Quartier = client.Quartier,
            };
        }

        public static Client Convert(this AddClientDto addClientDto)
        {
            return new Client
            {
                Nom = addClientDto.Nom,
                NumeroTelephone = addClientDto.NumeroTelephone,
                Email = addClientDto.Email,
                Quartier = addClientDto.Quartier,
            };
        }

        public static void UpdateClientDto(this Client client,UpdateClientDto updateClientDto)
        {

            client.Id = updateClientDto.Id;
            client.Nom = updateClientDto.Nom;
            client.NumeroTelephone = updateClientDto.NumeroTelephone;
            client.Email = updateClientDto.Email;
            client.Quartier = updateClientDto.Quartier;

        }
    }
}
