using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Application.AutoMapper.Dto
{
    public class AddClientDto
    {
        public string Nom { get; set; } = string.Empty;

        public string NumeroTelephone = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
    }
}
