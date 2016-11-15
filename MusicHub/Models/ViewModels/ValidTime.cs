using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicHub.Models.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var valid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);

            return (valid);

        }
    }
}
