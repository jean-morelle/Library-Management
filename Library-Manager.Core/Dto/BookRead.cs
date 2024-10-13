using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Infrastructure.Dto
{
    public class BookRead
    {
        public int LivreId { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string ISBN { get; set; }
        public List<EmprunterRead> Emprunts { get; set; } = new List<EmprunterRead>();
    }
}
