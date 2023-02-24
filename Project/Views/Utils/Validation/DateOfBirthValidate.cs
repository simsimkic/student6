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
    class DateOfBirthValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                string[] split = s.Split('/');
                if (split != null && split.Length == 3)
                {
                    if (Regex.IsMatch(split[0], @"^[0-9]+$") && Regex.IsMatch(split[1], @"^[0-9]+$") && Regex.IsMatch(split[2], @"^[0-9]+$"))
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                        return new ValidationResult(false, "Format Day/Month/Year(digits)");

                }
                else
                {
                    return new ValidationResult(false, "Format Day/Month/Year(digits)");
                }
            }
            catch
            {
                return new ValidationResult(false, "Exception");
            }
        }
    }

}
