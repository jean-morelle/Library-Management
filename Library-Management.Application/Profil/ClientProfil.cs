using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Librairi_Management.Domain.Models;
using Library_Management.Application.AutoMapper.Dto;

namespace Library_Management.Application.Profil
{
    public class ClientProfil:Profile
    {
        public ClientProfil()
        {
            CreateMap<Client, ClientReadDto>();
            CreateMap<ClientReadDto,Client>();
            CreateMap<Client,AddClientDto>();
            CreateMap<AddClientDto, Client>();
            CreateMap<Client,UpdateClientDto>();
            CreateMap<UpdateClientDto, Client>();
        }
    }
}
