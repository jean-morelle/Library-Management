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
    public class BookController : ControllerBase
    {
        private readonly ILivreService _LivreService;
        private readonly IMapper mapper;

        public BookController(ILivreService LivreService,IMapper mapper)
        { 
            _LivreService = LivreService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
           
            var livres = _LivreService.GetLivres().ToList();
            return Ok(livres);
        }
        [HttpGet("{id}")]

        public IActionResult GetBook(int id)
        {
            var livre = _LivreService.GetLivre(id);
            if (livre == null)
            {
                NotFound(livre);
            }
            return Ok(livre);
        }
        [HttpPost]
        public ActionResult<Livre> AddBook(BookToAdd livre)
        {
            var bookModel = mapper.Map<Livre>(livre);
            _LivreService.Create(bookModel);
            return CreatedAtAction(nameof(GetBook), new { id = bookModel.LivreId }, bookModel);
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var livre = _LivreService.GetLivre(id);

            if (livre is null)
            {
                NotFound(livre);
            }
            _LivreService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookToUpdate livre)
        {
          

            if (id!=livre.LivreId)
            {
                return BadRequest();
            }

            var bookModel = mapper.Map<Livre>(livre);
            // Mise à jour des propriétés de getlivre avec celles de livre


            _LivreService.Update(bookModel);

            return Ok(bookModel);
        }

    }
}
