using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Models.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        [StringLength(128)]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable Genres { get; set; }

        public DateTime ToDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }

        public string Heading { get; set; }
    }
}
