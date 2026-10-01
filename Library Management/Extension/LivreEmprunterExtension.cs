using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Models;

namespace Library_Management.Extension
{
    public static class LivreEmprunterExtension
    {
        public static IEnumerable<LivreEmpruntReadDto> ConvertToDto(this IEnumerable<Emprunt> emprunts)
        {
            return emprunts.Select(emprunt => emprunt.ConvertTo());
        }

        // Le livre et le client doivent avoir été chargés (Include) par le repository
        public static LivreEmpruntReadDto ConvertTo(this Emprunt emprunt)
        {
            return new LivreEmpruntReadDto
            {
                Id = emprunt.Id,
                DateEmprunt = emprunt.DateEmprunt,
                DateRetour = emprunt.DateRetour,
                DateRetourEffective = emprunt.DateRetourEffective,
                EstRendu = emprunt.EstRendu,
                EnRetard = !emprunt.EstRendu && emprunt.DateRetour.Date < DateTime.Today,
                LivreId = emprunt.LivreId,
                TitleLivre = emprunt.Livre?.Titre ?? string.Empty,
                AuteurLivre = emprunt.Livre?.Auteur ?? string.Empty,
                Genre = emprunt.Livre?.Genre ?? string.Empty,
                ClientId = emprunt.ClientId,
                NomClient = emprunt.Client?.Nom ?? string.Empty,
                Email = emprunt.Client?.Email ?? string.Empty,
                Quartier = emprunt.Client?.Quartier ?? string.Empty,
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
            emprunt.DateEmprunt = updateLivreEmpruntDto.DateEmprunt;
            emprunt.DateRetour = updateLivreEmpruntDto.DateRetour;
        }
    }
}
