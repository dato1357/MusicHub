using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicHub.Models.ViewModels
{
    public class FutureDate : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            DateTime datetime;
            var valid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);

            return (valid && datetime > DateTime.Now);

        }
    }
}
