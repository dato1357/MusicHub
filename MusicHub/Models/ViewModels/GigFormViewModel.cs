using MusicHub.Controllers;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MusicHub.Models.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

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

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<GigsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;

            }
        }
    }
}
}
