using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.Views.Utils.Validation
{
    public class JmbgValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                if (Regex.IsMatch(s, @"^[0-9]{13}$"))
                {
                    return new ValidationResult(true, null);
                }
                else if(Regex.IsMatch(s, @"^[0-9]+$"))
                {
                    return new ValidationResult(false, "Needs to be lenght of 13");
                }
                else
                {
                    return new ValidationResult(false, "Not Valid JMBG");
                }
            }
            catch
            {
                return new ValidationResult(false, "Exception");
            }
        }
    }
}