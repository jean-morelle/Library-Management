using AutoMapper;
using Library_Management.Infrastructure.Dto;
using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Infrastructure.AutoMapper
{
    public class Profil : Profile
    {
        public Profil()
        {
            //--Source => Destination
            CreateMap<Livre,BookRead>();

            CreateMap<BookRead, Livre>();

            CreateMap<BookToUpdate, Livre>();

            CreateMap<UserRead, Utilisateur>();

            CreateMap<Utilisateur,UserRead>();

            CreateMap<UserToUpdate, Utilisateur>();

            CreateMap<EmprunterRead, Emprunt>();

            CreateMap<Emprunt, EmprunterRead>();

            CreateMap<EmpruntToUpdate,Emprunt>();
        }
    }
}
