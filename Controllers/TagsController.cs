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
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private readonly BloggingContext _context;

        public TagsController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/Get
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            var data = _context.Tag.OrderBy(x=>x.TagName);

            return data;
        }
    }
}
