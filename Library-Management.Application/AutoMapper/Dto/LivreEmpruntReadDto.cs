using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librairi_Management.Domain.Models;
using Library_Management.Models;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class LivreEmpruntReadDto
    {
        public Guid Id { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public string TitleLivre { get; set; } = string.Empty;
        public string AuteurLivre { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string NomClient { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
    }
}
