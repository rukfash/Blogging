using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Models;
using Blogging.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {

        private readonly BloggingContext _context;
        private readonly IPostService _postSvc;

        public PostsController(IPostService postSvc, BloggingContext context)
        {
            _context = context;
            _postSvc = postSvc;
        }

        // GET: api/Post
        [HttpGet]
        public IEnumerable<ViewModels.Post> GetPosts(string tag = "")
        {
            var data = _postSvc.GetPosts(tag);

            return data;
        }



        // GET: api/Get/slug
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetPost([FromRoute] string slug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Post = _postSvc.GetPost(slug);

            if (Post == null)
            {
                return NotFound();
            }

            return Ok(Post);
        }

        // PUT: api/Post/slug
        [HttpPut("{slug}")]
        public async Task<IActionResult> PutPost([FromRoute] string slug, [FromBody] ViewModels.Post PostViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (slug != PostViewModel.Slug)
            {
                return BadRequest();
            }

            var Post = _postSvc.PutPosts(PostViewModel);

            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(PostViewModel.Slug))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Post);
        }

        

        

        // POST: api/Post
        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] ViewModels.Post PostViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Post = _postSvc.PostPosts(PostViewModel);            

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateException)
            {
                if (PostExists(PostViewModel.Slug))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Ok(Post);
        }

        


        // DELETE: api/Post/slug
        [HttpDelete("{slug}")]
        public async Task<IActionResult> DeletePost([FromRoute] string slug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Post = _context.Post.Where(x=>x.Slug == slug).FirstOrDefault();
            var PostTags = _context.PostTag.Where(x => x.PostFk == Post.PostPk);

            if (Post == null)
            {
                return NotFound();
            }

            _context.PostTag.RemoveRange(PostTags);
            _context.SaveChanges();

            _context.Post.Remove(Post);
            await _context.SaveChangesAsync();

            return Ok(Post);
        }

        private bool PostExists(string slug)
        {
            return _context.Post.Any(e => e.Slug == slug);
        }
    }
}