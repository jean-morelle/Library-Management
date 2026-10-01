using System.ComponentModel.DataAnnotations;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class AddLivreEmpruntDto
    {
        [Required]
        public DateTime DateEmprunt { get; set; }
        [Required]
        public DateTime DateRetour { get; set; }
        [Required]
        public Guid LivreId { get; set; }
        [Required]
        public Guid ClientId { get; set; }
    }
}
