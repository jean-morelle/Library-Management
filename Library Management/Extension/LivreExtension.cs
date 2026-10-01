using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Models;

namespace Library_Management.Extension
{
    public static class LivreExtension
    {
        public static IEnumerable<LivreReadDto> ConvertToDto(this IEnumerable<Livre> livres)
        {
            return livres.Select(livre => livre.ConvertTo());
        }

        public static LivreReadDto ConvertTo(this Livre livre)
        {
            return new LivreReadDto
            {
                Id = livre.Id,
                Titre = livre.Titre,
                Auteur = livre.Auteur,
                Genre = livre.Genre,
                Disponible = livre.Emprunts.All(e => e.EstRendu)
            };
        }

        public static Livre ConvertToAdd( this AddLivreDto addLivreDto)
        {
            return new Livre
            {
                Titre = addLivreDto.Titre.Trim(),
                Auteur = addLivreDto.Auteur.Trim(),
                Genre = addLivreDto.Genre.Trim()
            };
        }

        public static void UpdateLivre(this Livre livre,UpdateLivreDTO updateLivreDTO)
        {
            livre.Titre = updateLivreDTO.Titre.Trim();
            livre.Auteur = updateLivreDTO.Auteur.Trim();
            livre.Genre = updateLivreDTO.Genre.Trim();
        }
    }
}
