using AutoMapper;
using Library_Management.Models;
using Library_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreControler : ControllerBase
    {
        private readonly ILivreService _LivreService;
        private readonly IMapper mapper;

        public LivreControler(ILivreService LivreService,IMapper mapper)
        { 
            _LivreService = LivreService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult All()
        {
           // var livreModel = mapper.Map<Livre>(new Livre());
            var GetLivreAll = _LivreService.Livres().ToList();
            return Ok(GetLivreAll);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var GetLivreById = _LivreService.GetLivreId(id);
            if (GetLivreById == null)
            {
                NotFound(GetLivreById);
            }
            return Ok(GetLivreById);
        }
        [HttpPost]
        public ActionResult<Livre> Post(Livre livre)
        {
            _LivreService.create(livre);
            return CreatedAtAction(nameof(GetById), new { id = livre.LivreId }, livre);
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var DeleteLivre = _LivreService.GetLivreId(id);

            if (DeleteLivre is null)
            {
                NotFound(DeleteLivre);
            }
            _LivreService.delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Livre livre)
        {
            if (id != livre.LivreId)
                return BadRequest();

            _LivreService.update(livre);
            return NoContent();
        }
    }
}
