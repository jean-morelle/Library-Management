using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Infrastructure.Dto
{
    public class EmpruntToAdd
    {
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
       
    }
}
