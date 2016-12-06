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
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .ToList();

            return View(gigs);
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
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("Create", model);
            }

            var newGig = new Gig
            {
                Venue = model.Venue,
                ArtistId = User.Identity.GetUserId(),
                GenreId = model.Genre,
                DateTime = model.ToDateTime()
            };

            _context.Gigs.Add(newGig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
