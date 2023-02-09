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
    public class ReviewsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        public readonly IUnitOfWork _unitOfWork;

        //public ReviewsController(ApplicationDbContext context)
        public ReviewsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reviews
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        public async Task<IActionResult> GetReviews()
        {
            //return await _context.Reviews.ToListAsync();
            var reviews = await _unitOfWork.Reviews.GetAll(includes: q => q.Include(x =>x.Product).Include(x => x.Customer));
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Review>> GetReview(int id)
        public async Task<IActionResult> GetReview(int id)
        {
            //var productReview = await _context.Reviews.FindAsync(id);
            var productReview = await _unitOfWork.Reviews.Get(q => q.Id == id);

            if (productReview == null)
            {
                return NotFound();
            }

            return Ok(productReview);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review productReview)
        {
            if (id != productReview.Id)
            {
                return BadRequest();
            }

            //_context.Entry(productReview).State = EntityState.Modified;
            _unitOfWork.Reviews.Update(productReview);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ReviewExists(id))
                if (!await ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review productReview)
        {
            //_context.Reviews.Add(productReview);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Reviews.Insert(productReview);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetReview", new { id = productReview.Id }, productReview);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            //var productReview = await _context.Reviews.FindAsync(id);
            var productReview = await _unitOfWork.Reviews.Get(q => q.Id == id);
            if (productReview == null)
            {
                return NotFound();
            }

            //_context.Reviews.Remove(productReview);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Reviews.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ReviewExists(int id)
        private async Task<bool> ReviewExists(int id)
        {
            //return _context.Reviews.Any(e => e.Id == id);
            var productReview = await _unitOfWork.Reviews.Get(q => q.Id == id);
            return productReview != null;
        }
    }
}
