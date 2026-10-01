using System.ComponentModel.DataAnnotations;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class AddLivreDto
    {
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        public string Titre { get; set; } = string.Empty;
        [Required(ErrorMessage = "L'auteur est obligatoire.")]
        public string Auteur { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
