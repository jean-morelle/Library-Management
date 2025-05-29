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
    public class EmpruntLivreProfil :Profile
    {
        public EmpruntLivreProfil()
        {
            CreateMap<Emprunt, LivreEmpruntReadDto>();
            CreateMap<LivreEmpruntReadDto, Emprunt>();
            CreateMap<Emprunt,AddLivreEmpruntDto>();
            CreateMap<AddLivreEmpruntDto, Emprunt>();
            CreateMap<Emprunt,UpdateLivreEmpruntDto>();
            CreateMap<UpdateLivreEmpruntDto, Emprunt>();
        }
    }
}
