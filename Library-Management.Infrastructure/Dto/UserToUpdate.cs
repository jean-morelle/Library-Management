using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Infrastructure.Dto
{
    public class UserToUpdate
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    }
}
