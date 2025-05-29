using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management.Models;

namespace Librairi_Management.Domain.Models
{
    public class Client
    {
        public  Guid Id { get; set; }
        public string Nom { get; set; }=string.Empty;

        public string NumeroTelephone = string .Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier {  get; set; } =string.Empty; 
        public List<Emprunt>emprunts = new List<Emprunt>();
    }
}
