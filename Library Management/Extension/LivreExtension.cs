using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Models;

namespace Library_Management.Extension
{
    public static class LivreExtension
    {
        public static IEnumerable<LivreReadDto> ConvertToDto(this IEnumerable<Livre> livres)
        {
            var result = from livre in livres
                         select new LivreReadDto
                         {
                             Id = livre.Id,
                             Auteur = livre.Auteur,
                             Titre = livre.Titre,
                             Genre = livre.Genre
                         };
            return result;
        }
        public static LivreReadDto ConvertTo(this Livre livres)
        {
            return new LivreReadDto
            {
                Id = livres.Id,
                Titre = livres.Titre,
                Auteur = livres.Auteur,
                Genre = livres.Genre
            };
        }
        public static Livre ConvertToAdd( this AddLivreDto addLivreDto)
        {
            return new Livre
            {
             Titre=addLivreDto.Titre,
            Auteur =addLivreDto.Auteur,
            Genre =addLivreDto.Genre

            };
        }
        public static void UpdateLivre(this Livre livre,UpdateLivreDTO updateLivreDTO)
        {
            livre.Id = updateLivreDTO.Id;
            livre.Auteur =updateLivreDTO.Auteur;
            livre.Titre = updateLivreDTO.Titre;
            livre.Genre=updateLivreDTO.Genre;   
        }
    }
}
