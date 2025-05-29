using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librairi_Management.Domain.Models;
using Library_Management.Models;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class AddLivreEmpruntDto
    {
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public Guid LivreId { get; set; }
        public Guid ClientId { get; set; }
    }
}
