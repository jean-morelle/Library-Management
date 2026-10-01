using System.ComponentModel.DataAnnotations;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class AddClientDto
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; } = string.Empty;
        public string NumeroTelephone { get; set; } = string.Empty;
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
    }
}
