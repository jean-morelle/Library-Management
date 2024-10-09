using Library_Management.Models;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UserController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }
        [HttpGet]
        public IActionResult GetAll() {

            var GetUilisateur = _utilisateurService.GetUtilisateurs().ToList();
            return Ok(GetUilisateur);

        }

        [HttpGet("{Id}")]
        public IActionResult GetUtilisateur(int UtilisateurId) {

            var utilisateur = _utilisateurService.GetUtilisateur(UtilisateurId);
            
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
            return CreatedAtAction(nameof(GetUtilisateur),new {id = utilisateur.UtilisateurId},utilisateur);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete (int utilisateurId)
        {
            var DeleteUtilisateur = _utilisateurService.GetUtilisateur(utilisateurId);

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
            if (id != utilisateur.UtilisateurId)
                return BadRequest();

            _utilisateurService.Update(utilisateur);
            return NoContent();
        }
    }
}
