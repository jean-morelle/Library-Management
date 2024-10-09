using AutoMapper;
using Library_Management.Infrastructure.Dto;
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
        private readonly IMapper mapper;

        public UserController(IUtilisateurService utilisateurService, IMapper mapper)
        {
            _utilisateurService = utilisateurService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll() {

            var utilisateurs = _utilisateurService.GetUtilisateurs().ToList();
            return Ok(utilisateurs);

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

        public IActionResult AddUser(UserToAdd utilisateur)
        {
            var user = mapper.Map<Utilisateur>(utilisateur);
            _utilisateurService.Create(user);
            return CreatedAtAction(nameof(GetUtilisateur),new {id = user.UtilisateurId},user);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser (int utilisateurId)
        {
            var utilisateur = _utilisateurService.GetUtilisateur(utilisateurId);

            if(utilisateur is null)
            {
                NotFound(utilisateur);
            }
            _utilisateurService.Delete(utilisateurId);
            return NoContent();


        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
                return BadRequest();

            _utilisateurService.Update(utilisateur);
            return NoContent();
        }
    }
}
