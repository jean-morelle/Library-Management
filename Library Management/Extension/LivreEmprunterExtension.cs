using System.Runtime.CompilerServices;
using Librairi_Management.Domain.Models;
using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Models;

namespace Library_Management.Extension
{
    public static class LivreEmprunterExtension
    {
     public static IEnumerable<LivreEmpruntReadDto> ConvertToDto(
     this IEnumerable<Client> clients,
        IEnumerable<Livre> livres,
        IEnumerable<Emprunt> emprunts)
        {
            var result = from emprunt in emprunts
                         join client in clients on emprunt.ClientId equals client.Id
                         join livre in livres on emprunt.LivreId equals livre.Id
                         select new LivreEmpruntReadDto
                         {
                             Id = emprunt.Id,
                             DateEmprunt = emprunt.DateEmprunt,
                             DateRetour = emprunt.DateRetour,
                             NomClient = client.Nom,
                             Email = client.Email,
                             Quartier=client.Quartier,
                             TitleLivre =livre.Titre,
                             Genre=livre.Genre,
                             AuteurLivre =livre.Auteur,
                         };

            return result;
        }
        public static LivreEmpruntReadDto ConvertTo(this Client client, Livre livre, Emprunt emprunt)
        {
            return new LivreEmpruntReadDto
            {
                Id = emprunt.Id,
                DateEmprunt = emprunt.DateEmprunt,
                DateRetour = emprunt.DateRetour,
                NomClient = client.Nom,
                Email = client.Email,
                Quartier = client.Quartier,
                TitleLivre = livre.Titre,
                Genre = livre.Genre,
                AuteurLivre = livre.Auteur,
            };
        }

        public static Emprunt ConverToAdd(this AddLivreEmpruntDto addLivreEmpruntDto)
        {
            return new Emprunt
            {
                ClientId = addLivreEmpruntDto.ClientId,
                LivreId = addLivreEmpruntDto.LivreId,
                DateEmprunt = addLivreEmpruntDto.DateEmprunt,
                DateRetour = addLivreEmpruntDto.DateRetour,
            };
        }

        public static void Update(this Emprunt emprunt, UpdateLivreEmpruntDto updateLivreEmpruntDto)
        {
            emprunt.ClientId = updateLivreEmpruntDto.ClientId;
            emprunt.LivreId = updateLivreEmpruntDto.LivreId;
            emprunt.DateEmprunt =updateLivreEmpruntDto.DateEmprunt;
            emprunt.DateRetour = updateLivreEmpruntDto.DateRetour;
        }
    }
}
