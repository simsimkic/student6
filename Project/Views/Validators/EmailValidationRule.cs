using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.Views.Validators
{
    public class EmailValidationRule : ValidationRule
    {
        private const string Pattern = "";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            => Regex.IsMatch(value as string, Pattern)
            ? new ValidationResult(false, "Required field.")
            : ValidationResult.ValidResult;
    }
}
