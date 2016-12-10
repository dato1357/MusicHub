using Microsoft.AspNet.Identity;
using MusicHub.DTOS;
using MusicHub.Models;
using System.Linq;
using System.Web.Http;

namespace MusicHub.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {

            var userId = User.Identity.GetUserId();

            if (_context
                .Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("Attendance already exists");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
