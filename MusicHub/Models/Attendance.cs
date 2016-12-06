using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }

        [Column(Order = 2)]
        [Key]
        public string AttendeeId { get; set; }
    }
}
