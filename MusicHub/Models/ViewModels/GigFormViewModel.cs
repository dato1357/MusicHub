using System.Collections;

namespace MusicHub.Models.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Genre { get; set; }

        public IEnumerable Genres { get; set; }



    }
}
