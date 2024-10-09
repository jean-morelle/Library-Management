using AutoMapper;
using Library_Management.Infrastructure.Dto;
using Library_Management.Models;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntController : ControllerBase
    {
        private readonly IEmpruntServices _empruntServices;
        private readonly IMapper mapper;

        public EmpruntController(IEmpruntServices empruntServices, IMapper mapper)
        {
            _empruntServices = empruntServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll() { 
        
           var emprunts =_empruntServices.GetEmprunts().ToList();
            return Ok(emprunts);
        }

        [HttpGet("{id}")]

        public IActionResult GetEmprunt(int id)
        {
            var emprunt =_empruntServices.GetEmprunt(id);
            if(emprunt is null)
            {
                NotFound();
            }
            return Ok(emprunt);
        }

        [HttpPost]
        public IActionResult AddEmprunt(EmpruntToAdd emprunt)
        {
            var empruntModel = mapper.Map<Emprunt>(emprunt);
            _empruntServices.Create(empruntModel);
            return CreatedAtAction(nameof(GetEmprunt), new { id = empruntModel.EmpruntId }, empruntModel        );
        }
        [HttpDelete]
        public IActionResult DeleteEmprunt(int id)
        {
            var RemoveEmprunt = _empruntServices.GetEmprunt(id);
            if (RemoveEmprunt is null)
            {
                NotFound(RemoveEmprunt);
            }
            _empruntServices.Delete(id);
            return NoContent();
            
        }
        [HttpPut]
        public IActionResult UpdateEmprunt(int id,Emprunt emprunt)
        {
            if(id != emprunt.EmpruntId)
            {
                BadRequest();
            }
            _empruntServices.Update(emprunt);
            return NoContent();
        }
    }
}
