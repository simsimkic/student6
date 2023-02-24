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
    public class NumberValidate:ValidationRule
    {
        public int Min
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
        try
        {
            var s = value as string;


            if (Regex.IsMatch(s, @"^[0-9]+$"))
            {
                int number = Int32.Parse(s);
                if (number >= Min && number <= Max)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Number is out of bounds");
            }
            else if (Regex.IsMatch(s, @"^[a-zA-Z0-9\s]+$"))
            {
                return new ValidationResult(false, "Can only contain digits");
            }
            else
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
