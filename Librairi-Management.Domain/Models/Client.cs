using Library_Management.Models;

namespace Librairi_Management.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string NumeroTelephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
        public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    }
}
