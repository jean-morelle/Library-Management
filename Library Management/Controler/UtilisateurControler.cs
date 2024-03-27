using Library_Management.Models;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurControler : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurControler(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }
        [HttpGet]
        public IActionResult GetAll() {

            var GetUilisateur = _utilisateurService.GetUtilisateurs().ToList();
            return Ok(GetUilisateur);

        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int UtilisateurId) {

            var utilisateur = _utilisateurService.GetUtilisateurById(UtilisateurId);
            
            if(utilisateur is null)
            {
                NotFound(utilisateur);
            }
            return Ok(utilisateur);
                
            // validation de l utilisateur 
            
        }

        [HttpPost]

        public IActionResult Post(Utilisateur utilisateur)
        {
            _utilisateurService.Create(utilisateur);
            return CreatedAtAction(nameof(GetById),new {id = utilisateur.Id},utilisateur);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete (int utilisateurId)
        {
            var DeleteUtilisateur = _utilisateurService.GetUtilisateurById(utilisateurId);

            if(DeleteUtilisateur is null)
            {
                NotFound(DeleteUtilisateur);
            }
            _utilisateurService.Delete(utilisateurId);
            return NoContent();


        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
                return BadRequest();

            _utilisateurService.Update(utilisateur);
            return NoContent();
        }
    }
}
