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

namespace CommentReview.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        public readonly IUnitOfWork _unitOfWork;

        //public CommentsController(ApplicationDbContext context)
        public CommentsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Comments
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        public async Task<IActionResult> GetComments()
        {
            //return await _context.Comments.ToListAsync();
            var comments = await _unitOfWork.Comments.GetAll(includes: q => q.Include(x => x.Customer));
            return Ok(comments);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Comment>> GetComment(int id)
        public async Task<IActionResult> GetComment(int id)
        {
            //var comment = await _context.Comments.FindAsync(id);
            var comment = await _unitOfWork.Comments.Get(q => q.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            //_context.Entry(comment).State = EntityState.Modified;
            _unitOfWork.Comments.Update(comment);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CommentExists(id))
                if (!await CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            //_context.Comments.Add(comment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Comments.Insert(comment);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            //var comment = await _context.Comments.FindAsync(id);
            var comment = await _unitOfWork.Comments.Get(q => q.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            //_context.Comments.Remove(comment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Comments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CommentExists(int id)
        private async Task<bool> CommentExists(int id)
        {
            //return _context.Comments.Any(e => e.Id == id);
            var comment = await _unitOfWork.Comments.Get(q => q.Id == id);
            return comment != null;
        }
    }
}
