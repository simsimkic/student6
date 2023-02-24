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
    class PostCodeValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                
                var s = value as string;
                if (Regex.IsMatch(s, @"^[0-9]{5}$"))
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Not Valid Postal Code");
                }
            }
            catch
            {
                return new ValidationResult(false, "Exception");
            }
        }
    }
}
