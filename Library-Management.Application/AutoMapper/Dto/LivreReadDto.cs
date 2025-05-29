using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class LivreReadDto
    {
        public Guid Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
