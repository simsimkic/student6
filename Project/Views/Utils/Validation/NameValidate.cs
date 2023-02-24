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
    public class NameValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                if (Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                {
                    return new ValidationResult(true, null);
                }
                else if(Regex.IsMatch(s, @"^[a-zA-Z0-9\s]+$"))
                {
                    return new ValidationResult(false, "Can only contain letters");
                }else
                {
                    return new ValidationResult(false, "Not Valid");
                }
            }
            catch
            {
                return new ValidationResult(false, "Not proper format");
            }
        }
    }
}
