using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReview.Server.Data;
using ProductReview.Server.IRepository;
using ProductReview.Shared.Domain;

namespace ProductReview.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        public readonly IUnitOfWork _unitOfWork;

        //public GenresController(ApplicationDbContext context)
        public GenresController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Genres
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        public async Task<IActionResult> GetGenres()
        {
            //return await _context.Genres.ToListAsync();
            var genres = await _unitOfWork.Genres.GetAll();
            return Ok(genres);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Genre>> GetGenre(int id)
        public async Task<IActionResult> GetGenre(int id)
        {
            //var productGenre = await _context.Genres.FindAsync(id);
            var productGenre = await _unitOfWork.Genres.Get(q=> q.Id == id);

            if (productGenre == null)
            {
                return NotFound();
            }

            return Ok(productGenre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre productGenre)
        {
            if (id != productGenre.Id)
            {
                return BadRequest();
            }

            //_context.Entry(productGenre).State = EntityState.Modified;
            _unitOfWork.Genres.Update(productGenre);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!GenreExists(id))
                if (!await GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre productGenre)
        {
            //_context.Genres.Add(productGenre);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Genres.Insert(productGenre);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGenre", new { id = productGenre.Id }, productGenre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            //var productGenre = await _context.Genres.FindAsync(id);
            var productGenre = await _unitOfWork.Genres.Get(q => q.Id == id);
            if (productGenre == null)
            {
                return NotFound();
            }

            //_context.Genres.Remove(productGenre);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Genres.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool GenreExists(int id)
        private async Task<bool> GenreExists(int id)
        {
            //return _context.Genres.Any(e => e.Id == id);
            var productGenre = await _unitOfWork.Genres.Get(q => q.Id == id);
            return productGenre != null;
        }
    }
}
