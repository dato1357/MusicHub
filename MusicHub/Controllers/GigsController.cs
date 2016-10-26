using Microsoft.AspNet.Identity;
using MusicHub.Models;
using MusicHub.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MusicHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel model)
        {
            var newGig = new Gig
            {
                Venue = model.Venue,
                ArtistId = User.Identity.GetUserId(),
                GenreId = model.Genre,
                DateTime = model.ToDateTime
            };

            _context.Gigs.Add(newGig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
