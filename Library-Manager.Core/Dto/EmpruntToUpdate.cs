﻿using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Infrastructure.Dto
{
    public  class EmpruntToUpdate
    {
        public int EmpruntId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public int UtilisateurId { get; set; }

        public int LivreId { get; set; }
    }
}
