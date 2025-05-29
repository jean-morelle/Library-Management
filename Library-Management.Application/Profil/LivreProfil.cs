using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library_Management.Application.AutoMapper.Dto;
using Library_Management.Models;

namespace Library_Management.Application.Profil
{
    public class LivreProfil: Profile
    {
        public LivreProfil()
        {
            CreateMap<Livre,LivreReadDto>();
            CreateMap<LivreReadDto, Livre>();
            CreateMap<Livre, AddLivreDto>();
            CreateMap<AddLivreDto, Livre>();
            CreateMap<Livre, UpdateLivreDTO>();
            CreateMap<UpdateLivreDTO, Livre>();
        }
    }
}
