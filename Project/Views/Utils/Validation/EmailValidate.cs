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
    public class EmailValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                if (Regex.IsMatch(s, @"^[a-zA-Z0-9\.]+@[a-zA-Z0-9\.]+\.[a-zA-Z]+$"))
                {
                    return new ValidationResult(true, null);
                }else
                {
                    return new ValidationResult(false, "Not Valid Email");
                }
            }
            catch
            {
                return new ValidationResult(false, "exepcion");
            }
        }
    }
}
