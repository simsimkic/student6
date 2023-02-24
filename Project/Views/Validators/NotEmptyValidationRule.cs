﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project.Views.Validators
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            => string.IsNullOrWhiteSpace((value ?? "").ToString())
            ? new ValidationResult(false, "Required field.")
            : ValidationResult.ValidResult;
    }
}
