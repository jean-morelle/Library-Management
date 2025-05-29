using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librairi_Management.Domain.Models
{
    public class Utilisateur
    {

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // pas le mot de passe brut !
        public string Role { get; set; } // ex: "Admin", "Client", etc.
    }
}
