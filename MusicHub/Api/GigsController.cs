using Microsoft.AspNet.Identity;
using MusicHub.Models;
using System.Linq;
using System.Web.Http;

namespace MusicHub.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            gig.IsCanceled = true;
            _context.SaveChanges();
            return Ok();

        }
    }
}
