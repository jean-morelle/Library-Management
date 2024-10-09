using Library_Management.Models;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntControler : ControllerBase
    {
        private readonly IEmpruntServices _empruntServices;

        public EmpruntControler(IEmpruntServices empruntServices)
        {
            _empruntServices = empruntServices;
        }
        [HttpGet]
        public IActionResult GetAll() { 
        
           var GetEmprunt =_empruntServices.GetEmprunts().ToList();
            return Ok(GetEmprunt);
        }

        [HttpGet("{id}")]

        public IActionResult GetByIdEmprunt(int id)
        {
            var GetId =_empruntServices.GetEmpruntId(id);
            if(GetId is null)
            {
                NotFound(GetId);
            }
            return Ok(GetId);
        }

        [HttpPost]
        public IActionResult Post(Emprunt emprunt)
        {
            _empruntServices.create(emprunt);
            return CreatedAtAction(nameof(GetByIdEmprunt), new { id = emprunt.EmpruntId }, emprunt);
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var RemoveEmprunt = _empruntServices.GetEmpruntId(id);
            if (RemoveEmprunt is null)
            {
                NotFound(RemoveEmprunt);
            }
            _empruntServices.delete(id);
            return NoContent();
            
        }
        [HttpPut]
        public IActionResult put(int id,Emprunt emprunt)
        {
            if(id != emprunt.EmpruntId)
            {
                BadRequest();
            }
            _empruntServices.update(emprunt);
            return NoContent();
        }
    }
}
